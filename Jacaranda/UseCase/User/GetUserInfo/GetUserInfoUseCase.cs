using System;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase.Interfaces.Repositories;
using Models = Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.User.GetUserInfo
{
    public class GetUserInfoUseCase : IUseCase<GetUserInfoUseCaseInput, GetUserInfoUseCaseOutput>
    {
        private readonly IUserRepository _userRepository;

        public GetUserInfoUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserInfoUseCaseOutput> Run(GetUserInfoUseCaseInput Input)
        {
            try
            {
                var User = await _userRepository.GetById(Input.UserId);

                if (User is null)
                {
                    throw new InvalidUserIdException();
                }

                return BuildResponse(User);

            }
            catch (Exception)
            {
                throw new InvalidUserIdException();
            }
        }

        private static GetUserInfoUseCaseOutput BuildResponse(Models.User User)
        {
            return new GetUserInfoUseCaseOutput
            {
                Id = User.Id,
                Name = User.Name,
                Photo = User.Photo,
                Email = User.Email,
                City = User.City,
                AllowNewsletter = User.AllowNewsletter
            };
        }

    }
}

