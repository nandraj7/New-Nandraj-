using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;

namespace LeadTracker.API.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IBranchRepository, BranchRepository>();

            services.AddScoped<ICodeRepository, CodeRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IOrganisationRepository, OrganisationRepository>();

            services.AddScoped<IPermissionRepository, PermissionRepository>();

            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();

            services.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}
