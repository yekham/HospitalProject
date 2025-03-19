using Core.DataAccess.Repositories;
using Core.Security.Entities;
using HospitalAppointmentProject.DataAccess.Contexts;
using HospitalProject.DataAccess.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalProject.DataAccess.Repositories.Concretes;

public sealed class UserRepository : EfRepositoryBase<User, int, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context) : base(context)
    {
    }
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await Context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        return Context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<Role>> GetUserRolesAsync(int userId)
    {
        return await Context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Include(ur => ur.Role)
            .Select(ur => ur.Role)
            .ToListAsync();
    }
}

