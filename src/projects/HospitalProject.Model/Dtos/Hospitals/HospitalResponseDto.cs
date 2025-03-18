﻿namespace HospitalProject.Model.Dtos.Hospitals;

public sealed record HospitalResponseDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? Address { get; init; }
    public string? City { get; init; }

}
