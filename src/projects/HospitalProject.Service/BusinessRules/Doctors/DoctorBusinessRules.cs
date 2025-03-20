using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalProject.DataAccess.Repositories.Abstracts;
using HospitalProject.Service.Constants.Doctors;

public class DoctorBusinessRules
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorBusinessRules(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task CheckDoctorLimitInHospital(int hospitalId, string specialty, CancellationToken cancellationToken = default)
    {
        // Aynı uzmanlığa sahip doktor sayısını kontrol et
        var doctorCount = await _doctorRepository.CountAsync(
            d => d.HospitalId == hospitalId && d.Specialty == specialty, cancellationToken);

        if (doctorCount >= 10)
        {
            throw new BusinessException(DoctorMessages.DoctorMaxSpecialty);
        }
    }
    public async Task DoctorIsPresentAsync(int id)
    {
        var isPresent = await _doctorRepository.AnyAsync(x => x.Id == id);
        if (!isPresent)
        {
            throw new NotFoundException(DoctorMessages.DoctorNotFound);
        }
    }
    public async Task CheckDoctorNameIsUnique(string name, string surname)
    {
        var isUnique = await _doctorRepository.AnyAsync(x => x.FirstName == name && x.LastName ==surname);
        if (isUnique)
        {
            throw new BusinessException(DoctorMessages.DoctorAlreadyExists);
        }
    }
}