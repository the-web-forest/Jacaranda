namespace Jacaranda.Domain.Exceptions;

public class InvalidPasswordException : BaseException
{
    public InvalidPasswordException() : base("001", "Invalid Username Or Password")  { }
}
