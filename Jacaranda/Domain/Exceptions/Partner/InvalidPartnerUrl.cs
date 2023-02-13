using System.Runtime.Serialization;

namespace Jacaranda.Domain.Exceptions
{
    [Serializable]
    public class InvalidPartnerUrlException : BaseException
    {
        public InvalidPartnerUrlException() : base("008", "Invalid Partner Url") { }

        protected InvalidPartnerUrlException(SerializationInfo info, StreamingContext context) : base("008", "Invalid Partner Url") { }
    }
}
