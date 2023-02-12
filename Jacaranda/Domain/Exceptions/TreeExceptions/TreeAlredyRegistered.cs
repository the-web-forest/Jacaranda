namespace Jacaranda.Domain.Exceptions;
public class InvalidTreeNameException : BaseException
{
    public InvalidTreeNameException() : base("004", "Tree Name Already Registered") { }
}