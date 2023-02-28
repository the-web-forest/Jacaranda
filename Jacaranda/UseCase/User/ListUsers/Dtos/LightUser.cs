using Models = Jacaranda.Domain.Model;

namespace Jacaranda.UseCase.ListUsers.Dtos
{
	public class LightUser
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Email { get; set; }

        public static LightUser FromUser(Models.User User)
        {
            return new LightUser
            {
                City = User.City.Name,
                State = User.City.State.Initials,
                Id = User.Id,
                Email = User.Email,
                Name = User.Name
            };
        }
    }
}

