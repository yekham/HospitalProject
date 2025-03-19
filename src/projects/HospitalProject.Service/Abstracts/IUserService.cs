using Core.Security.Entities;
using HospitalProject.Model.Dtos.Users;
using System.Linq.Expressions;

namespace HospitalProject.Service.Abstracts;

public interface IUserService
{
    Task<List<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<UserResponseDto?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<UserResponseDto?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);

    Task<UserResponseDto> AddAsync(User user, CancellationToken cancellationToken = default);
    Task<UserResponseDto> DeleteAsync(int id, CancellationToken cancellationToken);

    Task<User> GetAsync(Expression<Func<User, bool>> filter, bool include = true, bool enableTracking = true, CancellationToken cancellationToken = default);


    Task<UserResponseDto> GetByIdAsync(int id);

    Task<User> UpdateAsync(User user, CancellationToken cancellationToken = default);


}
