﻿using AutoMapper;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;
using HospitalProject.DataAccess.Repositories.Abstracts;
using HospitalProject.Model.Dtos.Doctors;
using HospitalProject.Model.Entities;
using HospitalProject.Service.Abstracts;
using HospitalProject.Service.Constants.Doctors;

namespace HospitalProject.Service.Concretes;

public sealed class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;
    private readonly DoctorBusinessRules _doctorBusinessRules;
    private readonly IValidator<DoctorAddRequestDto> _doctorAddRequestValidator;

    public DoctorService(IDoctorRepository doctorRepository, IMapper mapper, DoctorBusinessRules doctorBusinessRules, IValidator<DoctorAddRequestDto> doctorAddRequestValidator)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
        _doctorBusinessRules = doctorBusinessRules;
        _doctorAddRequestValidator = doctorAddRequestValidator;
    }

    public async Task<string> AddAsync(DoctorAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        await ValidationTool.ValidateAsync(_doctorAddRequestValidator, dto);
        await _doctorBusinessRules.CheckDoctorNameIsUnique(dto.FirstName, dto.LastName);
        await _doctorBusinessRules.CheckDoctorLimitInHospital(dto.HospitalId, dto.Specialty, cancellationToken);
        Doctor doctor = _mapper.Map<Doctor>(dto);
        await _doctorRepository.AddAsync(doctor, cancellationToken);
        return DoctorMessages.DoctorAdded;
    }

    public async Task<string> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _doctorBusinessRules.DoctorIsPresentAsync(id);
        Doctor doctor = await _doctorRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);
        await _doctorRepository.DeleteAsync(doctor, cancellationToken);
        return DoctorMessages.DoctorDeleted;
    }

    public async Task<List<DoctorResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Doctor> doctors = await _doctorRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var doctorResponseDtos = _mapper.Map<List<DoctorResponseDto>>(doctors);
        return doctorResponseDtos;
    }

    public async Task<List<DoctorResponseDto>> GetAllByHospitalIdAsync(int hospitalId, CancellationToken cancellationToken = default)
    {
        List<Doctor> doctors = await _doctorRepository.GetAllAsync(filter: x => x.HospitalId == hospitalId, enableTracking: false, cancellationToken: cancellationToken);
        var doctorResponseDtos = _mapper.Map<List<DoctorResponseDto>>(doctors);
        return doctorResponseDtos;
    }

    public async Task<DoctorResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await _doctorBusinessRules.DoctorIsPresentAsync(id);
        Doctor doctor = await _doctorRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);
        DoctorResponseDto doctorResponseDto = _mapper.Map<DoctorResponseDto>(doctor);
        return doctorResponseDto;
    }

    public async Task<string> UpdateAsync(DoctorUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _doctorBusinessRules.DoctorIsPresentAsync(dto.Id);
        Doctor doctor = _mapper.Map<Doctor>(dto);
        await _doctorRepository.UpdateAsync(doctor, cancellationToken);
        return DoctorMessages.DoctorUpdated;
    }
}
