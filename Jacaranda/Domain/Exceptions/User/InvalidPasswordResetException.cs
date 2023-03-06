using System;
namespace Jacaranda.Domain.Exceptions.User
{
    public class InvalidPasswordResetException : BaseException
    {
        public InvalidPasswordResetException() : base("009", "Invalid Password Reset Request") { }
    }
}

