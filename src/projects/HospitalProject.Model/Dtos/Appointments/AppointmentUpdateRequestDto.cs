﻿namespace HospitalProject.Model.Dtos.Appointments;

public sealed record AppointmentUpdateRequestDto
{
    public int Id { get; init; }
    public DateTime AppointmentDate { get; init; }
    public string? Notes { get; init; }
    public int DoctorId { get; init; }
    public int PatientId { get; init; }
}
