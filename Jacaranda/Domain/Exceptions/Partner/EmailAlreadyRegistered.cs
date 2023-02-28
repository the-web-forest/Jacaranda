using System.Runtime.Serialization;

namespace Jacaranda.Domain.Exceptions
{
    [Serializable]
    public class EmailAlreadyRegisteredException : BaseException
    {
        public EmailAlreadyRegisteredException() : base("012", "Partner Email Already Registered") { }

        protected EmailAlreadyRegisteredException(SerializationInfo info, StreamingContext context) : base("012", "Partner Email Already Registered") { }
    }
}
