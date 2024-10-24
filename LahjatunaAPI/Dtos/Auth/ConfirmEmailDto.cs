﻿using System.ComponentModel.DataAnnotations;

namespace LahjatunaAPI.Dtos.Auth
{
    public class ConfirmEmailDto
    {
        [Required]
        public string? UserId { get; set; }

        [Required]
        public string? Token { get; set; }
    }
}
