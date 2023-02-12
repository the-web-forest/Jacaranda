using System;
using Jacaranda.Domain.Exceptions;
using Models = Jacaranda.Domain.Model;
using Jacaranda.UseCase;
using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.UseCase.User.Detail
{
	public class UserDetailUseCase: IUseCase<UserDetailUseCaseInput, UserDetailUseCaseOutput>
	{
        public readonly IUserRepository _userRepository;

		public UserDetailUseCase(IUserRepository userRepository)
		{
            _userRepository = userRepository;
		}

        public async Task<UserDetailUseCaseOutput> Run(UserDetailUseCaseInput Input)
        {
            var User = await GetUserById(Input.Id);

            if(User is null)
            {
                throw new InvalidUserIdException();
            }

            return BuildOutput(User);
        }

        private async Task<Models.User> GetUserById(int UserId)
        {
            try
            {
                return await _userRepository.GetById(UserId);
            } catch 
            {
                throw new InvalidUserIdException();
            }
        }

        private UserDetailUseCaseOutput BuildOutput(Models.User User)
        {
            return new UserDetailUseCaseOutput
            {
                Id = User.Id,
                Name = User.Name,
                City = User.City.Name,
                State = User.City.State.Initials,
                Email = User.Email,
                CreatedAt = User.CreatedAt,
                UpdatedAt = User.UpdatedAt,
                EmailVerified = User.EmailVerified
            };
        }
    }
}

