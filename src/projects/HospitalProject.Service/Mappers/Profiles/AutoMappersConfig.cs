using AutoMapper;
using Core.Security.Entities;
using HospitalProject.Model.Dtos.Appointments;
using HospitalProject.Model.Dtos.Doctors;
using HospitalProject.Model.Dtos.Hospitals;
using HospitalProject.Model.Dtos.Patients;
using HospitalProject.Model.Dtos.Users;
using HospitalProject.Model.Entities;
using System.Globalization;

namespace HospitalProject.Service.Mappers.Profiles;

public sealed class AutoMappersConfig : Profile
{
    public AutoMappersConfig()
    {
        CreateMap<Appointment, AppointmentResponseDto>()
            .ForMember(dest => dest.AppointmentDate,
                opt => opt.MapFrom(src => src.AppointmentDate.ToString("dd.MM.yyyy")))
            .ForMember(dest => dest.AppointmentDay,
                opt => opt.MapFrom(src => src.AppointmentDate.Day))
            .ForMember(dest => dest.AppointmentMonth,
                opt => opt.MapFrom(src => src.AppointmentDate.ToString("MMMM", new CultureInfo("tr-TR"))))
            .ForMember(dest => dest.AppointmentYear,
                opt => opt.MapFrom(src => src.AppointmentDate.Year));
        CreateMap<AppointmentAddRequestDto, Appointment>();
        CreateMap<AppointmentUpdateRequestDto, Appointment>();

        CreateMap<DoctorAddRequestDto, Doctor>();
        CreateMap<DoctorUpdateRequestDto, Doctor>();
        CreateMap<Doctor, DoctorResponseDto>();

        CreateMap<HospitalAddRequestDto, Hospital>();
        CreateMap<HospitalUpdateRequestDto, Hospital>();
        CreateMap<Hospital, HospitalResponseDto>();

        CreateMap<PatientAddRequestDto, Patient>();
        CreateMap<PatientUpdateRequestDto, Patient>();
        CreateMap<Patient, PatientResponseDto>();

        CreateMap<User, UserResponseDto>().ReverseMap();
        CreateMap<RegisterRequestDto, User>();
        CreateMap<UserUpdateRequestDto, User>();
    }
}
