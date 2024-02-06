using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IEmployeeService
    {
        Task CreateEmployee(EmployeeDTO employee);
        Task<EmployeeDTO> RegisterEmployee(NewEmployeeDTO employee, int orgId, int userId);
        //Task RegisterEmployee(NewEmployeeDTO employee, int orgId, int userId);

       // Task<EmployeeDTO> GetEmployeeByIdAsync(int id);

        Task<IEnumerable<EmployeeDTO>> GetAllEmployeeAsync();

        Task UpdateEmployeeAsync(int id, EmployeeDTO employee);

        Task<Employee> EditEmployeeAsync(int id, NewEmployeeDTO updatedEmployee);

        Task<EmployeeDetailsDTO> GetEmployeeDetailsByIdAsync(int id);

        Task<EmployeeDTO> DeleteEmployeeAsync(int id, int userId);

        Task<List<spParentAndChildrenDTO>> GetspEmployeesByUserIdAsync(int userId, int orgId);

        Task<bool> ChangePasswordAsync(ChangePasswordDTO changePassword);

        Task<List<spParentDTO>> GetspParentOfUsersAsync();

        Task<List<spGetActivitiesResponseDTO>> GetspActivitiesAsync(spGetActivitiesRequestDTO activities);

        Task<List<spGetTimelineResponseDTO>> GetTimelineAsync(spGetTimelineRequestDTO timeline);

        Task<List<spGetEmployeeBookingSummaryResponseDTO>> GetEmployeeBookingSummary(spGetEmployeeBookingSummaryRequestDTO request);

        Task<string> GetEmployeeStatus(int id);

    }
}
