using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jacaranda.Controllers.Partners
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Admin")]
    public class PartnerController: ControllerBase
    {
        private readonly ILogger<PartnerController> _logger;

        public PartnerController(ILogger<PartnerController> logger)
		{
            _logger = logger;
		}

        [HttpGet]
        public ObjectResult Get()
        {
            return new ObjectResult("Oi");
        }
	}
}

