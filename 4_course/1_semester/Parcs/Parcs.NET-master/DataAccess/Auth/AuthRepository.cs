using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly HostServerContext _ctx;

        private readonly UserManager<User, int> _userManager;

        public AuthRepository()
        {
            _ctx = new HostServerContext();
            _userManager = new UserManager<User, int>(new UserStore<User, Role, int, UserLogin, UserRole, UserClaim>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new User
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public Task<User> FindUser(string userName, string password)
        {
            return _userManager.FindAsync(userName, password);
        }


        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
