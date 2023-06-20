using SharedLibrary.Dtos;
using UdemyAuthServer.Core.Dtos;

namespace UdemyAuthServer.Core.Services
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);

        Task<Response<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken);


        /// <summary>
        /// Bu meto sayesin refresh token silebiliriz. 
        /// Logout olduğunda, yada kötü niyetli birşey sezdiğimizde refresh token null atayarak soruna çözüm üretiriz
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken);


        Task<Response<ClientTokenDto>> CreateTokenByClientAsync(CLientLoginDto cLientLoginDto);

    }
}
