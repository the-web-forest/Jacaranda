using System;
using Jacaranda.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Jacaranda.Controllers.User
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<ObjectResult> Register()
        {
            return new ObjectResult("Precisamos Implementar");
        }
    }
}

