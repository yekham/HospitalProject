using Core.DataAccess.Repositories;
using Core.Security.Entities;

namespace HospitalProject.DataAccess.Repositories.Abstracts;

public interface IUserRoleRepository : IAsyncRepository<UserRole, int>, IRepository<UserRole, int>
{
}
