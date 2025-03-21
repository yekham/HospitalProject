namespace HospitalProject.Model.Dtos.Appointments;

public sealed record AppointmentResponseDto
{
    public int Id { get; init; }
    public string AppointmentDate { get; init; }
    public string? Notes { get; init; }
    public int PatientId { get; init; }
    public int DoctorId { get; init; }


    public int AppointmentDay { get; init; }
    public string AppointmentMonth { get; init; }
    public int AppointmentYear { get; init; }
    //null geliyor / eager loading yapildi

    //public string? PatientName { get; init; }
    //public string? DoctorName { get; init; }
}
