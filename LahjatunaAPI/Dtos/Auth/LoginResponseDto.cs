﻿// Ignore Spelling: Dto

namespace LahjatunaAPI.Dtos
{
    public class LoginResponseDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public List<string>? Role { get; set; }
        public string? Token { get; set; }
    }
}
