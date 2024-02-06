using LeadTracker.API;
using LeadTracker.API.Entities;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetUserLoginAsync(string mobile, string password);

        List<spParentAndChildrenDTO> GetEmployeesByUserIdAsync(int userId, int orgId);

        Task<bool> ChangePasswordAsync(int id, string currentPassword, string newPassword);

        Task UpdateEmployeeDeviceIdAsync(int employeeId, string deviceId);

        List<spParentDTO> GetspParentOfUsersByOrgIdAsync();

        List<spGetActivitiesResponseDTO> GetspActivitiesByFiltersAsync(spGetActivitiesRequestDTO activities);

        List<spGetTimelineResponseDTO> GetspTimelineByFilterAsync(spGetTimelineRequestDTO timelines);

        List<spGetEmployeeBookingSummaryResponseDTO> GetEmployeeBookingSummaryAsync(spGetEmployeeBookingSummaryRequestDTO request);

        int? GetParentUserIdByEmployeeId(int employeeId);

        List<int?> GetParentUserIdsByUserIds(AttendanceApprovalRequestDTO attendances);

        Task RegisterNewEmployeeAsync(List<Employee> employee);
        Task CreateEducation(Education education);
        Task CreateBankDetail(BankDetail bankDetail);


        Task<BankDetail> GetBankDetailByEmployeeIdAsync(int id);
        Task<Education> GetEducationByEmployeeIdAsync(int id);

        List<spParentDTO> GetEmployeeAndParentByUserIdAsync(int EmployeeId);

        Task<string> GetEmployeeNameByIdAsync(int employeeId);
        Task<List<int>> GetAllEmployeeIdsAsync();

        Task<Employee> GetEmployeeById(int id);

        Task<string> GetUserNameByIdAsync(int id);
    }
}
