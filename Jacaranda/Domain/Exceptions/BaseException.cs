using System;
namespace Jacaranda.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string Code, string Message)
        {
            Data.Add("Code", "JAC-" + Code);
            Data.Add("Message", Message);
            Data.Add("ShortMessage", Message.Replace(" ", string.Empty));
        }
    }
}

