using Core.DataAccess.Repositories;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalProject.DataAccess.Repositories.Abstracts;
using HospitalProject.Model.Entities;

namespace HospitalProject.DataAccess.Repositories.Concretes;

public sealed class PatientRepository: EfRepositoryBase<Patient, int, BaseDbContext>, IPatientRepository
{
    public PatientRepository(BaseDbContext context) : base(context)
    {
    }
}
