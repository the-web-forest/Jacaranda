using System;
namespace Jacaranda.Domain.Exceptions.Certificate
{
    public class InvalidCertificateException : BaseException
    {
        public InvalidCertificateException() : base("002", "Invalid Certificate Id") { }
    }
}

