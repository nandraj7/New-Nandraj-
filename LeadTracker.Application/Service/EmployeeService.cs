using AutoMapper;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeerepository;
        private readonly IMapper _mappingProfile;

        public EmployeeService(IMapper mappingProfile, IEmployeeRepository employeeService)
        {
            _mappingProfile = mappingProfile;
            _employeerepository = employeeService;

        }

        public async Task CreateEmployee(EmployeeDTO employee)
        {
            var empl = _mappingProfile.Map<Employee>(employee);
            await _employeerepository.CreateAsync(empl).ConfigureAwait(false);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeerepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            var employees = await _employeerepository.GetAllAsync();
            return employees.ToList();
        }

        public async Task UpdateEmployeeAsync(EmployeeDTO employee)
        {
            var empl = _mappingProfile.Map<Employee>(employee);
            await _employeerepository.UpdateAsync(empl);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _employeerepository.GetByIdAsync(id);
            if (employee != null)
            {
                await _employeerepository.DeleteAsync(id);
            }
        }
    }
}
