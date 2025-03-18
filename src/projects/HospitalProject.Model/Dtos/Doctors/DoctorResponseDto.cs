namespace HospitalProject.Model.Dtos.Doctors;

public sealed record DoctorResponseDto
{
    public int Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Specialty { get; init; }
    public string? HospitalName { get; init; }
}
