using System.Reflection;

namespace Jacaranda.Configuration.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(
                Assembly.GetAssembly(typeof(DtoToModelMappingProfile)),
                Assembly.GetAssembly(typeof(ModelToDtoMappingProfile)));
        }
    }
}
