using System;
using Newtonsoft.Json;

namespace Jacaranda.External.Services.DTOS.Mail
{
    public class SendEmailTemplateDataItem
    {
        [JsonProperty("quantity")]
        public string? Quantity { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}

