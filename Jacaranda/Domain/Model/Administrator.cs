﻿using System;
namespace Jacaranda.Domain.Model
{
    public class Administrator : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

