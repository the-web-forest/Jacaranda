using System;
namespace Jacaranda.Domain.Exceptions.Mail
{
    public class InvalidEmailValidationException : BaseException
    {
        public InvalidEmailValidationException() : base("005", "Invalid Email Validation") { }
    }
}

