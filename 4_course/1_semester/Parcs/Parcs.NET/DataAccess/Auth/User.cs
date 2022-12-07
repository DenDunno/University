using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess.Auth
{
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
    }

    public class Role : IdentityRole<int, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }

    public class UserClaim : IdentityUserClaim<int>
    {
    }

    public class UserRole : IdentityUserRole<int>
    {
    }

    public class UserLogin : IdentityUserLogin<int>
    {
    }
}
