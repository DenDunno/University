using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace DataAccess.Auth
{
    public interface IAuthRepository : IDisposable
    {
        Task<IdentityResult> RegisterUser(UserModel userModel);
        Task<User> FindUser(string userName, string password);
    }
}