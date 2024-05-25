using JWTImplementation.Models;
using JWTImplementation.Request_Model;

namespace JWTImplementation.Interfaces
{
    public interface IAuthService
    {
        User AddUser(User user);
        string Login(LoginRequest loginRequest);
    }
}
