namespace HospitalProject.Service.Constants.Appointments;

public static class AppointmentMessages
{
    public const string AppointmentAlreadyExists = "Appointment already exists";
    public const string AppointmentNotFound = "Appointment not found";
    public const string AppointmentAdded = "Appointment added successfully";
    public const string AppointmentRulesForPatient = "Bir hasta bir doktordan 1 hafta içinde en fazla 1 randevu alabilir.";
    public const string AppointmentUpdated = "Appointment updated successfully";
    public const string AppointmentDeleted = "Appointment deleted successfully";
    public const string DateRequired = "Date is required";
    public const string NotesRequired = "Notes is required";
    public const string MinimumLengthMessage = "Name must be at least 2 characters";
    public const string MaximumLengthMessage = "Name must be at most 50 characters";
}
