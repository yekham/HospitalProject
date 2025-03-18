﻿using Core.DataAccess.Entities;
using System.Reflection.Metadata;

namespace Core.Security.Entities;

public class User : Entity<int>
{
    public string? Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();

}
