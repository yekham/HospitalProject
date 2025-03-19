using Core.Security.JWT;
using HospitalProject.Model.Dtos.Users;

namespace HospitalProject.Service.Abstracts;

public interface IAuthService
{

    Task<AccessToken> RegisterAsync(RegisterRequestDto requestDto, CancellationToken cancellationToken = default);
    Task<AccessToken> LoginAsync(LoginRequestDto requestDto, CancellationToken cancellationToken = default);

    Task<AccessToken> UpdateUserAsync(int id, UserUpdateRequestDto userUpdateRequestDto);




}
