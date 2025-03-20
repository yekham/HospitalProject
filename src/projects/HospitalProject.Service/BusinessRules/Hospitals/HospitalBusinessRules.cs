using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalProject.DataAccess.Repositories.Abstracts;
using HospitalProject.Service.Constants.Hospitals;

namespace HospitalProject.Service.BusinessRules.Hospitals;

public sealed class HospitalBusinessRules(IHospitalRepository hospitalRepository)
{
    public async Task HospitalIsPresentAsync(int id)
    {
        var isPresent = await hospitalRepository.AnyAsync(x => x.Id == id);
        if (!isPresent)
        {
            throw new NotFoundException(HospitalMessages.HospitalNotFound);
        }
    }
    public async Task CheckHospitalNameIsUnique(string name)
    {
        // Hastane isminin benzersiz olup olmadığını kontrol et
        var isUnique = await hospitalRepository.AnyAsync(x => x.Name == name);
        if (isUnique)
        {
            throw new BusinessException(HospitalMessages.HospitalNameNotUnique);
        }
    }
}
