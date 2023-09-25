using LeadTracker.Application.IService;
using LeadTracker.Application.Service;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Infrastructure;

namespace LeadTracker.API.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrgnisationService, OrganisationService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICodeService, CodeService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<IRoleService, RoleService>();
        }
    }
}
