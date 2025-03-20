using AutoMapper;
using HospitalProject.DataAccess.Repositories.Abstracts;
using HospitalProject.DataAccess.Repositories.Concretes;
using HospitalProject.Model.Dtos.Patients;
using HospitalProject.Model.Entities;
using HospitalProject.Service.Abstracts;
using HospitalProject.Service.BusinessRules.Hospitals;
using HospitalProject.Service.BusinessRules.Patients;
using HospitalProject.Service.Constants.Hospitals;
using HospitalProject.Service.Constants.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Service.Concretes;

public sealed class PatientService : IPatientService
{
    private readonly IMapper _mapper;
    private readonly IPatientRepository _patientRepository;
    private readonly PatientBusinessRules _patientBusinessRules;

    public PatientService(IMapper mapper, IPatientRepository patientRepository, PatientBusinessRules patientBusinessRules)
    {
        _mapper = mapper;
        _patientRepository = patientRepository;
        _patientBusinessRules = patientBusinessRules;
    }

    public async Task<string> AddAsync(PatientAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _patientBusinessRules.CheckPatientNameIsUnique(dto.FirstName, dto.LastName);
        Patient patient = _mapper.Map<Patient>(dto);
        await _patientRepository.AddAsync(patient, cancellationToken);
        return PatientMessages.PatientAdded;
    }

    public async Task<string> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _patientBusinessRules.PatientIsPresentAsync(id);
        Patient patient = await _patientRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);
        await _patientRepository.DeleteAsync(patient, cancellationToken);
        return PatientMessages.PatientDeleted;
    }

    public async Task<List<PatientResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Patient> patients = await _patientRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var patientResponseDtos = _mapper.Map<List<PatientResponseDto>>(patients);
        return patientResponseDtos;
    }

    public async Task<PatientResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await _patientBusinessRules.PatientIsPresentAsync(id);
        Patient patient = await _patientRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);
        PatientResponseDto patientResponseDto = _mapper.Map<PatientResponseDto>(patient);
        return patientResponseDto;
    }

    public async Task<string> UpdateAsync(PatientUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _patientBusinessRules.PatientIsPresentAsync(dto.Id);
        Patient patient = _mapper.Map<Patient>(dto);
        await _patientRepository.UpdateAsync(patient, cancellationToken);
        return PatientMessages.PatientUpdated;
    }
}
