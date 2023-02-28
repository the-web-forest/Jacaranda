using System.Runtime.Serialization;

namespace Jacaranda.Domain.Exceptions
{
    [Serializable]
    public class InvalidPartnerEmailException : BaseException
    {
        public InvalidPartnerEmailException() : base("011", "Invalid Partner Email") { }

        protected InvalidPartnerEmailException(SerializationInfo info, StreamingContext context) : base("011", "Invalid Partner Email") { }
    }
}
