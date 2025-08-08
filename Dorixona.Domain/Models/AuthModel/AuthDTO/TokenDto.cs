﻿namespace Dorixona.Domain.Models.AuthModel.AuthDTO;

public class TokenDto
{
    public string AccessToken { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }
}
