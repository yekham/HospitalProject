﻿namespace HospitalProject.Model.Dtos.Doctors;

public sealed record class DoctorAddRequestDto
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Specialty { get; init; }
    public int HospitalId { get; init; }
}
