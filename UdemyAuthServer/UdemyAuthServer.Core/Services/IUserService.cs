using Microsoft.AspNetCore.Http.HttpResults;
using SharedLibrary.Dtos;
using UdemyAuthServer.Core.Dtos;

namespace UdemyAuthServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<Response<UserAppDto>> GetUserByNameAsync(string userName);

        Task<Response<NoContent>> CreateUserRoles(string username);
    }
}
