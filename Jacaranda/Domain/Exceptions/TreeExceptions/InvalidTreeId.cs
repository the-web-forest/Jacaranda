namespace Jacaranda.Domain.Exceptions;
public class InvalidTreeIdException : BaseException
{
    public InvalidTreeIdException() : base("005", "Invalid Tree Id") { }
}