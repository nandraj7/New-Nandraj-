using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeerepository.GetByIdAsync(id)
;

            var employeeDTO = _mappingProfile.Map<EmployeeDTO>(employee);
            return employeeDTO;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeeAsync()
        {
            var employees = await _employeerepository.GetAllAsync();
            var employeesDTO = _mappingProfile.Map<List<EmployeeDTO>>(employees);
            return employeesDTO.ToList();
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeDTO employee)
        {
            var existingEmployee = await _employeerepository.GetByIdAsync(id);


            _mappingProfile.Map(employee, existingEmployee);


            await _employeerepository.UpdateAsync(existingEmployee);

            //var empl = _mappingProfile.Map<Employee>(employee);
            //await _employeerepository.UpdateAsync(empl);
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
