using AccountManagement.Application;
using AccountManagement.Application.Account;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.AccountDomain;
using AccountManagement.Domain.RoleDomain;
using AccountManagement.Infrastructure.EFCore.AccountManagementDbContext;
using AccountMangement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootStrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IAccountApplication, AccountApplication>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddDbContext<AccountContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
