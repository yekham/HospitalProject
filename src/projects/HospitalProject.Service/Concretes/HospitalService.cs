using AutoMapper;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;
using HospitalProject.DataAccess.Repositories.Abstracts;
using HospitalProject.Model.Dtos.Hospitals;
using HospitalProject.Model.Entities;
using HospitalProject.Service.Abstracts;
using HospitalProject.Service.BusinessRules.Hospitals;
using HospitalProject.Service.Constants.Hospitals;

namespace HospitalProject.Service.Concretes;

public sealed class HospitalService : IHospitalService
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly HospitalBusinessRules _hospitalBusinessRules;
    private readonly IMapper _mapper;
    private readonly IValidator<HospitalAddRequestDto> _hospitalAddRequestValidator;

    public HospitalService(IHospitalRepository hospitalRepository, HospitalBusinessRules hospitalBusinessRules, IMapper mapper, IValidator<HospitalAddRequestDto> hospitalAddRequestValidator)
    {
        _hospitalRepository = hospitalRepository;
        _hospitalBusinessRules = hospitalBusinessRules;
        _mapper = mapper;
        _hospitalAddRequestValidator = hospitalAddRequestValidator;
    }

    public async Task<string> AddAsync(HospitalAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        await ValidationTool.ValidateAsync(_hospitalAddRequestValidator, dto);
        await _hospitalBusinessRules.CheckHospitalNameIsUnique(dto.Name);
        Hospital hospital = _mapper.Map<Hospital>(dto);
        await _hospitalRepository.AddAsync(hospital,cancellationToken);
        return HospitalMessages.HospitalAdded;
    }

    public async Task<string> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _hospitalBusinessRules.HospitalIsPresentAsync(id);
        Hospital hospital = await _hospitalRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);
        await _hospitalRepository.DeleteAsync(hospital, cancellationToken);
        return HospitalMessages.HospitalDeleted;
    }

    public async Task<List<HospitalResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Hospital> hospitals = await _hospitalRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var hospitalResponseDtos = _mapper.Map<List<HospitalResponseDto>>(hospitals);
        return hospitalResponseDtos;
    }

    public async Task<HospitalResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await _hospitalBusinessRules.HospitalIsPresentAsync(id);
        Hospital hospital = await _hospitalRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);
        HospitalResponseDto hospitalResponseDto = _mapper.Map<HospitalResponseDto>(hospital);
        return hospitalResponseDto;
    }

    public async Task<string> UpdateAsync(HospitalUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _hospitalBusinessRules.HospitalIsPresentAsync(dto.Id);
        Hospital hospital = _mapper.Map<Hospital>(dto);
        await _hospitalRepository.UpdateAsync(hospital, cancellationToken);
        return HospitalMessages.HospitalUpdated;
    }
}
