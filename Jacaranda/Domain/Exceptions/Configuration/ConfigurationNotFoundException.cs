using System.Runtime.Serialization;
using Jacaranda.Domain.Exceptions;

namespace Ipe.Domain.Errors;

[Serializable]
public class ConfigurationNotFoundException : BaseException
{
    public ConfigurationNotFoundException() : base("017", "Portal configuration not found") { }
    protected ConfigurationNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}