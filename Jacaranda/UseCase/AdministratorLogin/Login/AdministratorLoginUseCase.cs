using System;
using Jacaranda.Domain;
using Jacaranda.Domain.Exceptions.Administrator;
using Jacaranda.External.Repositories;
using Jacaranda.Model;
using Jacaranda.UseCase.Interfaces;
using Jacaranda.UseCase.Interfaces.Repositories;
using BCryptLib = BCrypt.Net.BCrypt;


namespace Jacaranda.UseCase.AdministratorLogin
{
	public class AdministratorLoginUseCase: IUseCase<AdministratorLoginUseCaseInput, AdministratorLoginUseCaseOutput>
	{
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IAuthService _authService;

        public AdministratorLoginUseCase(IAdministratorRepository administratorRepository, IAuthService authService)
        {
            _administratorRepository = administratorRepository;
            _authService = authService;
        }

        public async Task<AdministratorLoginUseCaseOutput> Run(AdministratorLoginUseCaseInput Input)
        {
            var Administrator = await _administratorRepository.GetByEmail(Input.Email);

            ValidateAdministrator(Administrator);

            var passwordIsValid = BCryptLib.Verify(Input.Password, Administrator.Password);

            if (passwordIsValid is false)
                throw new InvalidPasswordException();

            return BuildResponse(Administrator);
        }

        private static void ValidateAdministrator(Administrator Admnistrator)
        {
            if (Admnistrator is null)
                throw new InvalidPasswordException();
        }

        private AdministratorLoginUseCaseOutput BuildResponse(Administrator Administrator)
        {
            return new AdministratorLoginUseCaseOutput
            {
                AccessToken = _authService.GenerateToken(Administrator, Roles.Admin),
                User = new OutputUser
                {
                    Id = Administrator.Id,
                    Email = Administrator.Email,
                    Name = Administrator.Name
                }
            };
        }
    }
}

