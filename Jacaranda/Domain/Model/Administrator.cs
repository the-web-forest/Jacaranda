using System;
namespace Jacaranda.Model
{
	public class Administrator: BaseModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}

