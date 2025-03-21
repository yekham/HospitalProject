namespace HospitalProject.Service.Constants.Patients;

public static class PatientMessages
{
    public const string PatientNotFound = "Patient not found";
    public const string PatientAdded = "Patient added successfully";
    public const string PatientUpdated = "Patient updated successfully";
    public const string PatientDeleted = "Patient deleted successfully";
    public const string PatientNameNotUnique = "Patient name must be unique";
    public const string MinimumLengthMessage = "Name must be at least 2 characters";
    public const string MaximumLengthMessage = "Name must be at most 50 characters";
    public const string FirstNameRequired = "First Name is required";
    public const string LastNameRequired = "Last Name is required";
    public const string BirthDateRequired = "Birth Date is required";
}
