using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalProject.DataAccess.Repositories.Abstracts;
using HospitalProject.Service.Constants.Patients;

namespace HospitalProject.Service.BusinessRules.Patients;

public sealed class PatientBusinessRules(IPatientRepository patientRepository)
{
    public async Task PatientIsPresentAsync(int id)
    {
        var isPresent = await patientRepository.AnyAsync(x => x.Id == id);
        if (!isPresent)
        {
            throw new NotFoundException(PatientMessages.PatientNotFound);
        }
    }
    public async Task CheckPatientNameIsUnique(string name, string lastname)
    {
        // Hastane isminin benzersiz olup olmadığını kontrol et
        var isUnique = await patientRepository.AnyAsync(x => x.FirstName == name && x.LastName == lastname);
        if (isUnique)
        {
            throw new BusinessException(PatientMessages.PatientNameNotUnique);
        }
    }
}
