namespace HospitalProject.Model.Dtos.Patients;

public sealed record PatientAddRequestDto
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public DateTime BirthDate { get; init; }
}
