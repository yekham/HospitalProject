namespace HospitalProject.Model.Dtos.Doctors;

public sealed record DoctorUpdateRequestDto
{
    public int Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Specialty { get; init; }
    public int HospitalId { get; init; }
}
