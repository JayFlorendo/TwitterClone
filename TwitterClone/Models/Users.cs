﻿using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
