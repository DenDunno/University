using System.Data.Entity;
using System.Data.Entity.Migrations;
using DataAccess.Auth;
using DataAccess.Logs;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess
{
    public class HostServerContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public DbSet<LogEntry> Logs { get; set; }

        public HostServerContext(): this("HostServerContext")
        {
        }

        public HostServerContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HostServerContext, Configuration>());
            Configuration.LazyLoadingEnabled = false;
        }
    }

    public class Configuration : DbMigrationsConfiguration<HostServerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
