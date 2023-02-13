using System.Runtime.Serialization;

namespace Jacaranda.Domain.Exceptions
{
    [Serializable]
    public class InvalidTreeObjectIdException : BaseException
    {
        public InvalidTreeObjectIdException() : base("007", "Invalid Tree Object Id") { }

        protected InvalidTreeObjectIdException(SerializationInfo info, StreamingContext context) : base("007", "Invalid Tree Object Id") { }
    }
}
