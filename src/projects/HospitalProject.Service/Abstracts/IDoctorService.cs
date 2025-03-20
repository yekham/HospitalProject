using HospitalProject.Model.Dtos.Doctors;

namespace HospitalProject.Service.Abstracts;

public interface IDoctorService
{
    Task<string> AddAsync(DoctorAddRequestDto dto, CancellationToken cancellationToken = default);
    Task<string> UpdateAsync(DoctorUpdateRequestDto dto, CancellationToken cancellationToken = default);
    Task<string> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<DoctorResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<DoctorResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<List<DoctorResponseDto>> GetAllByHospitalIdAsync(int hospitalId, CancellationToken cancellationToken = default);
}
