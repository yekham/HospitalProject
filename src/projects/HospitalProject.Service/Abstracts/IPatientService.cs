using HospitalProject.Model.Dtos.Hospitals;
using HospitalProject.Model.Dtos.Patients;

namespace HospitalProject.Service.Abstracts;

public interface IPatientService
{
    Task<string> AddAsync(PatientAddRequestDto dto, CancellationToken cancellationToken = default);
    Task<string> UpdateAsync(PatientUpdateRequestDto dto, CancellationToken cancellationToken = default);
    Task<string> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<PatientResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<PatientResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
