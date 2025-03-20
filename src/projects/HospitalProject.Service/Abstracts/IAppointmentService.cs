using HospitalProject.Model.Dtos.Appointments;

namespace HospitalProject.Service.Abstracts;

public interface IAppointmentService
{
    Task<string> AddAsync(AppointmentAddRequestDto dto, CancellationToken cancellationToken = default);
    Task<string> UpdateAsync(AppointmentUpdateRequestDto dto, CancellationToken cancellationToken = default);

    Task<string> DeleteAsync(int id, CancellationToken cancellationToken = default);

    Task<AppointmentResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<List<AppointmentResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);


    Task<List<AppointmentResponseDto>> GetAllByPatientIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<AppointmentResponseDto>> GetAllByDoctorIdAsync(int id, CancellationToken cancellationToken = default);
}
