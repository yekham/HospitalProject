using Core.CrossCuttingConcerns.Exceptions.Types;
using HospitalProject.DataAccess.Repositories.Abstracts;
using HospitalProject.DataAccess.Repositories.Concretes;
using HospitalProject.Service.Constants.Appointments;

namespace HospitalProject.Service.BusinessRules.Appointments;

public sealed class AppointmentBusinessRules(IAppointmentRepository appointmentRepository)
{
    public async Task AppointmentIsPresentAsync(int id)
    {
        var isPresent = await appointmentRepository.AnyAsync(x => x.Id == id);
        if (!isPresent)
        {
            throw new NotFoundException(AppointmentMessages.AppointmentNotFound);
        }
    }
    public async Task CheckIfPatientCanCreateAppointment(int patientId, int doctorId, DateTime appointmentDate)
    {
        // 1 hafta öncesi ve sonrası için tarih aralığı belirledik
        var startDate = appointmentDate.AddDays(-7);
        var endDate = appointmentDate.AddDays(7);

        // Hastanın bu doktordan 1 hafta içinde randevusu var mı kontrol etttik
        var existingAppointment = await appointmentRepository.AnyAsync(
            a => a.PatientId == patientId &&
                 a.DoctorId == doctorId &&
                 a.AppointmentDate >= startDate &&
                 a.AppointmentDate <= endDate);

        // Eğer varsa hata fırlattık
        if (existingAppointment)
        {
            throw new BusinessException(AppointmentMessages.AppointmentRulesForPatient);
        }
    }

}
