namespace HospitalProject.Service.Constants.Doctors;

public static class DoctorMessages
{
    public const string DoctorAlreadyExists = "Doctor already exists";
    public const string DoctorNotFound = "Doctor not found";
    public const string DoctorAdded = "Doctor added successfully";
    public const string DoctorMaxSpecialty = "Bir hastanede aynı uzmanlığa sahip sadece 10 doktor olabilir.";
    public const string DoctorUpdated = "Doctor updated successfully";
    public const string DoctorDeleted = "Doctor deleted successfully";
    public const string MinimumLengthMessage = "Name must be at least 2 characters";
    public const string MaximumLengthMessage = "Name must be at most 50 characters";
    public const string FirstNameRequired = "First Name is required";
    public const string LastNameRequired = "Last Name is required";
    public const string SpecialtyRequired = "Specialty is required";
}
