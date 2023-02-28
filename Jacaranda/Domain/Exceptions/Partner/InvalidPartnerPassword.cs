using System.Runtime.Serialization;

namespace Jacaranda.Domain.Exceptions
{
    [Serializable]
    public class InvalidPartnerPasswordException : BaseException
    {
        public InvalidPartnerPasswordException() : base("009", "Invalid Partner Password") { }

        protected InvalidPartnerPasswordException(SerializationInfo info, StreamingContext context) : base("009", "Invalid Partner Password") { }
    }
}
