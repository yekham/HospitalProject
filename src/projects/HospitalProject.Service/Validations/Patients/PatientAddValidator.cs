using FluentValidation;
using HospitalProject.Model.Dtos.Patients;
using HospitalProject.Service.Constants.Patients;

namespace HospitalProject.Service.Validations.Patients;

public class PatientAddValidator : AbstractValidator<PatientAddRequestDto>
{
    public PatientAddValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage(PatientMessages.FirstNameRequired).MinimumLength(3).WithMessage(PatientMessages.MinimumLengthMessage);
        RuleFor(x => x.LastName).NotEmpty().WithMessage(PatientMessages.LastNameRequired).MinimumLength(2).WithMessage(PatientMessages.MinimumLengthMessage);
        RuleFor(x => x.BirthDate).NotEmpty().WithMessage(PatientMessages.BirthDateRequired);

    }
}
