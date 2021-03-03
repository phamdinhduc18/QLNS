using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using QLNS.Helpers.Models;
using QLNS.Services;
using System;
using System.Threading.Tasks;

namespace QLNS.Controllers
{
    [Authorize]
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("/[controller]/[action]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthorizationController(IAuthService authService)
        {
            _authService = authService;
        }

        // /Authorization/login
        [EnableCors("MyPolicy")]
        [AllowAnonymous]
        [HttpPost]
        public Task<UserResponseDTO> Login(UserLoginDTO userLogin)
        {
            var result = _authService.Login(userLogin);
            return result;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var rfToken = refreshToken ?? Request.Cookies["refreshToken"];
            var response = await _authService.RefreshToken(rfToken);

            if (response == null)
                return Unauthorized(new { message = "Invalid token" });

            setTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        private void setTokenCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeToken(JObject objectForm)
        {
            var refreshToken = objectForm.Value<string>("refreshToken");
            // accept token from request body or cookie
            refreshToken ??= Request.Cookies["refreshToken"];

            if (string.IsNullOrWhiteSpace(refreshToken))
                return BadRequest(new { message = "Token is required" });

            var response = await _authService.RevokeToken(refreshToken);

            if (!response)
                return NotFound(new { message = "Token not found" });

            return Ok(new { message = "Token revoked" });
        }
        
    }
}
