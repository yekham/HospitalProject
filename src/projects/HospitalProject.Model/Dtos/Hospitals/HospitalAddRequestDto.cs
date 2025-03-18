namespace HospitalProject.Model.Dtos.Hospitals;

public sealed record HospitalAddRequestDto
{
    public string? Name { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }
}
