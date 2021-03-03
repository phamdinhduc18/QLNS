using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QLNS.Helpers;
using QLNS.Helpers.Models;
using QLNS.Models;
using QLNS.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.Services
{
    public class AuthService : IAuthService
    {
        private readonly EmployeeRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AuthService(EmployeeRepository employeeRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = employeeRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<UserResponseDTO> Login(UserLoginDTO userLogin)
        {
            string message;
            var user = _repo.CheckLogin(userLogin, out message);
            if (user == null)
                return new UserResponseDTO { Message = message };

            var userResponse = _mapper.Map<UserResponseDTO>(user);

            var refreshToken = generateRefreshToken();
            userResponse.RefreshToken = refreshToken.Token;

            user.RefreshToken.Add(refreshToken);
            await _repo.UpdateAsync(user.EmployeeId,user);
            //await _repo.SaveAsync();

            var token = genarateToken(userResponse);
            userResponse.AccessToken = token;
            return userResponse;

        }

        public async Task<UserResponseDTO> RefreshToken(string rfToken)
        {
            var user = await _repo.GetUserByToken(rfToken);
            if (user == null)
                return null;

            UserResponseDTO authResponse = _mapper.Map<UserResponseDTO>(user);
            var newRefreshToken = generateRefreshToken();

            _repo.UpdateRefreshTokenOfUser(rfToken, newRefreshToken, user);

            //await _repo.AddRefreshTokenAsync(refreshToken, user);
            //await _repo.AddRefreshTokenAsync(newRefreshToken, user);
            //await _repo.SaveAsync();
            
            authResponse.AccessToken = genarateToken(authResponse);
            authResponse.RefreshToken = newRefreshToken.Token;

            return authResponse;

        }


        public async Task<bool> RevokeToken(string token)=>await _repo.RevokeToken(token);

        private string genarateToken(UserResponseDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, !string.IsNullOrWhiteSpace(user.Position) ? user.Position : ""),
                    new Claim(Constants.CustomClaims.DEPARTMENT, !string.IsNullOrWhiteSpace(user.DepartmentName) ? user.DepartmentName : "")
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken generateRefreshToken()
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.Now.AddMinutes(100080),
                    Created = DateTime.Now
                };
            }
        }
    }
}