namespace HospitalProject.Model.Dtos.Patients;

public sealed record PatientUpdateRequestDto
{
    public int Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public DateTime BirthDate { get; init; }
}
