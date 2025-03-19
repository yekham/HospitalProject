using Core.DataAccess.Repositories;
using Core.Security.Entities;

namespace HospitalProject.DataAccess.Repositories.Abstracts;

public interface IUserRepository : IAsyncRepository<User, int>, IRepository<User, int>
{
    Task<User?> GetByEmailAsync(string email);
    Task<List<Role>> GetUserRolesAsync(int userId);
    Task<User?> GetByIdAsync(int id);
}
