﻿
using System.ComponentModel.DataAnnotations;

namespace Video_Game.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        

    }
}
