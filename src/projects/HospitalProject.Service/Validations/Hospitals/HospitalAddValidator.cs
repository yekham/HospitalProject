using FluentValidation;
using HospitalProject.Model.Dtos.Hospitals;
using HospitalProject.Service.Constants.Hospitals;
namespace HospitalProject.Service.Validations.Hospitals;

public class HospitalAddValidator : AbstractValidator<HospitalAddRequestDto>
{
    public HospitalAddValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(HospitalMessages.HospitalNameRequired).MinimumLength(2).WithMessage(HospitalMessages.MinimumLengthMessage);
        RuleFor(x => x.Address).NotEmpty().WithMessage(HospitalMessages.HospitalAddressRequired).MinimumLength(2).WithMessage(HospitalMessages.MinimumLengthMessage);
        RuleFor(x => x.City).NotEmpty().WithMessage(HospitalMessages.HospitalCityRequired).MinimumLength(2).WithMessage(HospitalMessages.MinimumLengthMessage);
    }
}
