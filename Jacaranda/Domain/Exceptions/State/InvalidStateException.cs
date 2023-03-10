using System;
namespace Jacaranda.Domain.Exceptions.State
{
    public class InvalidStateException : BaseException
    {
        public InvalidStateException() : base("007", "Invalid State") { }
    }
}

