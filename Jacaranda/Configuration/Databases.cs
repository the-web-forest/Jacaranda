using System;
using Jacaranda.Context;
using Jacaranda.External.Services;
using Jacaranda.UseCase.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Jacaranda.Configuration
{
    public static class Databases
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseMySQL(builder.Configuration["Database:ConnectionString"]);
            });
        }
    }
}

