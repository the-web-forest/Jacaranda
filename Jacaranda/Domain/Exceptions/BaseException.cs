using System;
using System.Runtime.Serialization;

namespace Jacaranda.Domain.Exceptions
{
    [Serializable]
    public class BaseException : Exception
    {
        protected BaseException() { }

        protected BaseException(string Code, string Message)
        {
            Data.Add("Code", "JAC-" + Code);
            Data.Add("Message", Message);
            Data.Add("ShortMessage", Message.Replace(" ", string.Empty));
        }

        protected BaseException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}

