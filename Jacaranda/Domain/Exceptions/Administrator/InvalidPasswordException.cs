using System;
namespace Jacaranda.Domain.Exceptions.Administrator
{
    public class InvalidPasswordException : BaseException
    {
        public InvalidPasswordException() : base("001", "Invalid Username Or Password") { }
    }
}

