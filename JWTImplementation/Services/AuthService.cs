using JWTImplementation.Context;
using JWTImplementation.Interfaces;
using JWTImplementation.Models;
using JWTImplementation.Request_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTImplementation.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtContext _jwtContext;
        private readonly IConfiguration _configuration;
        public AuthService(JwtContext jwtcontext, IConfiguration configuration)
        {
            _jwtContext = jwtcontext;
            _configuration = configuration;
        }
        public User AddUser(User user)
        {
           var addeduser = _jwtContext.users.Add(user);
            _jwtContext.SaveChanges();
            return addeduser.Entity;
        }

        public string Login(LoginRequest loginRequest)
        {
            if (loginRequest.userName != null && loginRequest.password!=null)
            {
                var user = _jwtContext.users.FirstOrDefault(x => x.Email == loginRequest.userName && x.Password == loginRequest.password);
                if (user != null)
                {
                    var Claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.name),
                        new Claim("Email", user.Email)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        claims: Claims,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        signingCredentials: creds);

                   string jettoken = (new JwtSecurityTokenHandler().WriteToken(token));
                    return jettoken;
                }

            }
            return "creds are not valid";
        }
    }
}
