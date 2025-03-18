﻿namespace Core.Security.JWT;

public class TokenOptions
{
    public int AccessTokenExpiration { get; set; }
    public string Audience { get; set; } = string.Empty; 
    public string Issuer { get; set; } = string.Empty;

    public string SecurityKey { get; set; } = string.Empty;
}