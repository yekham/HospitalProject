namespace HospitalProject.Model.Dtos.Users;

public sealed record UserUpdateRequestDto
{
    public string? Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
