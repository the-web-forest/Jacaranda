using System;
namespace Jacaranda.Domain.Exceptions.Mail
{
    public class UnverifiedEmailException : BaseException
    {
        public UnverifiedEmailException() : base("004", "Unverified Email") { }
    }
}

