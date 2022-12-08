using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace DataAccess.Auth
{
    public class ApplicationUserManager : UserManager<User, int>
    {
        // Configure the application user manager
        public ApplicationUserManager(IUserStore<User, int> store)
            : base(store)
        {
        }
    }
}
