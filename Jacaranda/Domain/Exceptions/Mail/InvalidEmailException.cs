using System;
using System.Runtime.Serialization;

namespace Jacaranda.Domain.Exceptions.Mail
{
    public class InvalidEmailException : BaseException
    {
        public InvalidEmailException() : base("008", "Invalid Email") { }
    }
}

