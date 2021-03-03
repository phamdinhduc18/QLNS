using QLNS.Helpers.Models;
using System.Threading.Tasks;

namespace QLNS.Services
{
    public interface IAuthService
    {
        public Task<UserResponseDTO> Login(UserLoginDTO userLogin);
        public Task<UserResponseDTO> RefreshToken(string refreshToken);
        public Task<bool> RevokeToken(string token);
    }
}