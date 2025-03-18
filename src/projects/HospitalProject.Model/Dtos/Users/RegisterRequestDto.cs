namespace HospitalProject.Model.Dtos.Users;

public sealed record RegisterRequestDto
{
    public string? Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
