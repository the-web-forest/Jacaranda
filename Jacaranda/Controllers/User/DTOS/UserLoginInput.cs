﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Jacaranda.Controllers.User.DTOS
{
    public class UserLoginInput
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}

