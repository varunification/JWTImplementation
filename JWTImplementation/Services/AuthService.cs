using JWTImplementation.Context;
using JWTImplementation.Interfaces;
using JWTImplementation.Models;
using JWTImplementation.Request_Model;

namespace JWTImplementation.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtContext _jwtContext;
        public AuthService(JwtContext jwtcontext)
        {
            _jwtContext = jwtcontext;
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

                }

            }
        }
    }
}
