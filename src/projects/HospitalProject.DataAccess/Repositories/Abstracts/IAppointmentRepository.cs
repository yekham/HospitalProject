using Core.DataAccess.Repositories;
using HospitalProject.Model.Entities;

namespace HospitalProject.DataAccess.Repositories.Abstracts;

public interface IAppointmentRepository : IRepository<Appointment,int>, IAsyncRepository<Appointment, int>
{
}
