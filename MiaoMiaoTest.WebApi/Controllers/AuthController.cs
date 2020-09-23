using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MiaoMiaoTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("login")]
        public async Task<string> Login()
        {
            return await Task.FromResult("请先登录");
        }

        [HttpGet("cookielogin ")]
        public async Task<IActionResult> CookieLogin(string userName)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim("Name", userName));
            await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return Content("login");
        }
        
        [HttpGet("jwtlogin")]
        public IActionResult JwtLogin([FromServices] SymmetricSecurityKey securityKey, string userName)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Name", userName)
            };

            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(issuer: "localhost", audience: "localhost", claims: claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return Content(accessToken);
        }
    }
}