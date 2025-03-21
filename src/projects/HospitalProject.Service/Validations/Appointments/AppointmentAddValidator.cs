using FluentValidation;
using HospitalProject.Model.Dtos.Appointments;
using HospitalProject.Service.Constants.Appointments;

namespace HospitalProject.Service.Validations.Appointments;

public class AppointmentAddValidator : AbstractValidator<AppointmentAddRequestDto>
{
    public AppointmentAddValidator()
    {
        RuleFor(x => x.Notes).NotEmpty().WithMessage(AppointmentMessages.NotesRequired).MinimumLength(2).WithMessage(AppointmentMessages.MinimumLengthMessage);
        RuleFor(x => x.AppointmentDate).NotEmpty().WithMessage(AppointmentMessages.DateRequired);
    }
}

