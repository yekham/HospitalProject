using Core.Security.Entities;
using Core.Security.JWT;

namespace HospitalProject.Service.Abstracts;

public interface IJwtService
{
    Task<AccessToken> CreateAccessTokenAsync(User user);
}
