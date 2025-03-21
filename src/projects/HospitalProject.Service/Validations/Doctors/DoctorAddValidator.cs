using FluentValidation;
using HospitalProject.Model.Dtos.Doctors;
using HospitalProject.Service.Constants.Doctors;

namespace HospitalProject.Service.Validations.Doctors;

public class DoctorAddValidator : AbstractValidator<DoctorAddRequestDto>
{
    public DoctorAddValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage(DoctorMessages.FirstNameRequired).MinimumLength(3).WithMessage(DoctorMessages.MinimumLengthMessage);
        RuleFor(x => x.LastName).NotEmpty().WithMessage(DoctorMessages.LastNameRequired).MinimumLength(2).WithMessage(DoctorMessages.MinimumLengthMessage);
        RuleFor(x => x.Specialty).NotEmpty().WithMessage(DoctorMessages.SpecialtyRequired).MinimumLength(2).WithMessage(DoctorMessages.MinimumLengthMessage);
    }
}
