using Core.DataAccess.Repositories;
using Core.Security.Entities;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalProject.DataAccess.Repositories.Abstracts;

namespace HospitalProject.DataAccess.Repositories.Concretes;

public sealed class UserRoleRepository : EfRepositoryBase<UserRole, int, BaseDbContext>, IUserRoleRepository
{
    public UserRoleRepository(BaseDbContext context) : base(context)
    {
    }
}
