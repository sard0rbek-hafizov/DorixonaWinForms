﻿    namespace Dorixona.Domain.Models.AuthModel.AuthDTO;

    public class LoginDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
