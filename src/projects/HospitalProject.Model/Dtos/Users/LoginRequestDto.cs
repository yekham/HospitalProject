namespace HospitalProject.Model.Dtos.Users;

public sealed record LoginRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }

}
