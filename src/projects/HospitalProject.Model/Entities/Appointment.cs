using Core.DataAccess.Entities;

namespace HospitalProject.Model.Entities;

public sealed class Appointment : Entity<int>
{
    public Appointment()
    {
        AppointmentDate = DateTime.Now;
        Notes = string.Empty;
    }
    public DateTime AppointmentDate { get; set; }
    public string Notes { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
}
