﻿using System;
namespace Jacaranda.Model
{
	public abstract class BaseModel
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public bool Deleted { get; set; }
    }
}

