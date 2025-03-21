using AutoMapper;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;
using HospitalProject.DataAccess.Repositories.Abstracts;
using HospitalProject.Model.Dtos.Appointments;
using HospitalProject.Model.Entities;
using HospitalProject.Service.Abstracts;
using HospitalProject.Service.BusinessRules.Appointments;
using HospitalProject.Service.Constants.Appointments;
using System.Threading;

namespace HospitalProject.Service.Concretes;

class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    private readonly AppointmentBusinessRules _appointmentBusinessRules;
    private readonly IValidator<AppointmentAddRequestDto> _appointmentAddRequestValidator;

    public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, AppointmentBusinessRules appointmentBusinessRules, IValidator<AppointmentAddRequestDto> appointmentAddRequestValidator)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
        _appointmentBusinessRules = appointmentBusinessRules;
        _appointmentAddRequestValidator = appointmentAddRequestValidator;
    }

    public async Task<string> AddAsync(AppointmentAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        await ValidationTool.ValidateAsync(_appointmentAddRequestValidator, dto);
        //Bir Hasta Bir Doktordan 1 Hafta İçinde En Fazla 1 Randevu Alabilir
        await _appointmentBusinessRules.CheckIfPatientCanCreateAppointment(dto.PatientId, dto.DoctorId, dto.AppointmentDate);

        Appointment appointment = _mapper.Map<Appointment>(dto);
        await _appointmentRepository.AddAsync(appointment, cancellationToken);
        return AppointmentMessages.AppointmentAdded;
    }

    public async Task<string> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _appointmentBusinessRules.AppointmentIsPresentAsync(id);
        Appointment appointment = await _appointmentRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);
        await _appointmentRepository.DeleteAsync(appointment, cancellationToken);
        return AppointmentMessages.AppointmentDeleted;
    }

    public async Task<List<AppointmentResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Appointment> appointments = await _appointmentRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var appointmentResponseDtos = _mapper.Map<List<AppointmentResponseDto>>(appointments);
        return appointmentResponseDtos;
    }

    public async Task<List<AppointmentResponseDto>> GetAllByDoctorIdAsync(int id, CancellationToken cancellationToken = default)
    {
        List<Appointment> appointments = await _appointmentRepository.GetAllAsync(filter: x => x.DoctorId == id, enableTracking: false, cancellationToken: cancellationToken);
        var appointmentResponseDtos = _mapper.Map<List<AppointmentResponseDto>>(appointments);
        return appointmentResponseDtos;
    }

    public async Task<List<AppointmentResponseDto>> GetAllByPatientIdAsync(int id, CancellationToken cancellationToken = default)
    {
        List<Appointment> appointments = await _appointmentRepository.GetAllAsync(filter: x => x.PatientId == id, enableTracking: false, cancellationToken: cancellationToken);
        var appointmentResponseDtos = _mapper.Map<List<AppointmentResponseDto>>(appointments);
        return appointmentResponseDtos;
    }

    public async Task<AppointmentResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        Appointment appointment = await _appointmentRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);
        AppointmentResponseDto appointmentResponseDto = _mapper.Map<AppointmentResponseDto>(appointment);
        return appointmentResponseDto;
    }

    public async Task<string> UpdateAsync(AppointmentUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _appointmentBusinessRules.AppointmentIsPresentAsync(dto.Id);
        Appointment appointment = _mapper.Map<Appointment>(dto);
        await _appointmentRepository.UpdateAsync(appointment, cancellationToken);
        return AppointmentMessages.AppointmentUpdated;
    }
}
