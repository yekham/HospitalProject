using Core.DataAccess.Repositories;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalProject.DataAccess.Repositories.Abstracts;
using HospitalProject.Model.Entities;

namespace HospitalProject.DataAccess.Repositories.Concretes;

public sealed class HospitalRepository : EfRepositoryBase<Hospital, int, BaseDbContext>, IHospitalRepository
{
    public HospitalRepository(BaseDbContext context) : base(context)
    {
    }
}
