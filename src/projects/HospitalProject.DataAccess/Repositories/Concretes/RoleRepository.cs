using Core.DataAccess.Repositories;
using Core.Security.Entities;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalProject.DataAccess.Repositories.Abstracts;

namespace HospitalProject.DataAccess.Repositories.Concretes;

public sealed class RoleRepository : EfRepositoryBase<Role, int, BaseDbContext>, IRoleRepository
{
    public RoleRepository(BaseDbContext context) : base(context)
    {
    }
}
