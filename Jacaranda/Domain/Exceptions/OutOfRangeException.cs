namespace Jacaranda.Domain.Exceptions;

public class OutOfRangeException : BaseException
{
    public OutOfRangeException() : base("002", "Out of Range")  { }
}
