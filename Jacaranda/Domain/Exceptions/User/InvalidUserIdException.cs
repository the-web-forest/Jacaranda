namespace Jacaranda.Domain.Exceptions;

public class InvalidUserIdException : BaseException
{
    public InvalidUserIdException() : base("003", "Invalid User Id")  { }
}
