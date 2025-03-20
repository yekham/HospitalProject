using HospitalProject.Model.Dtos.Hospitals;

namespace HospitalProject.Service.Abstracts;

public interface IHospitalService
{
    Task<string> AddAsync(HospitalAddRequestDto dto, CancellationToken cancellationToken = default);
    Task<string> UpdateAsync(HospitalUpdateRequestDto dto, CancellationToken cancellationToken = default);
    Task<string> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<HospitalResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<HospitalResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
}
