using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeadTracker.API.Entities;

namespace LeadTracker.Infrastructure.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly LeadTrackerContext _context;
        public EmployeeRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee> GetUserLoginAsync(string mobile, string password)
        {
            var users = _context.Employees.Where(a => a.Mobile == mobile && a.Password == password).ToList();

            return users.FirstOrDefault();
        }


        public List<spParentAndChildrenDTO> GetEmployeesByUserIdAsync(int userId, int orgId)
        {

            var result = new List<spParentAndChildrenDTO>();

            var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@UserId", userId),
                    new SqlParameter("@OrgId", orgId)
                };

            result = _context.Set<spParentAndChildrenDTO>().FromSqlRaw("GetEmployeesAndChildren @UserId, @OrgId", parameters.ToArray()).ToList();

            return result;

        }

        public async Task<bool> ChangePasswordAsync(int id, string currentPassword, string newPassword)
        {
            var user = await _context.Employees.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return false;
            }

            if (user.Password != currentPassword)
            {
                return false;
            }
            user.Password = newPassword;
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task UpdateEmployeeDeviceIdAsync(int employeeId, string deviceId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);

            if (employee != null)
            {
                employee.DeviceId = deviceId;
                await _context.SaveChangesAsync();
            }
        }

        public List<spParentDTO> GetspParentOfUsersByOrgIdAsync()
        {
            var parameters = new List<SqlParameter>
            {
            };

            var result = _context.Set<spParentDTO>()
                .FromSqlRaw("spGetAllParents", parameters.ToArray()).ToList();

            return result;

        }

        public List<spGetActivitiesResponseDTO> GetspActivitiesByFiltersAsync(spGetActivitiesRequestDTO activities)
        {
            try
            {
                var defFromDt = DateTime.Now.Date;
                var defToDt = DateTime.Now.Date.AddHours(23).AddMinutes(59);
                activities.RowsPerPage = activities.RowsPerPage <= 0 ? 100 : activities.RowsPerPage;
                activities.PageIndex = activities.PageIndex < 0 ? 0 : activities.PageIndex;
                activities.ExpectedFromDate = activities.ExpectedFromDate == DateTime.MinValue ? defFromDt : activities.ExpectedFromDate;
                activities.ExpectedToDate = activities.ExpectedToDate == DateTime.MinValue ? defToDt : activities.ExpectedToDate;
                activities.SearchTerm = string.IsNullOrEmpty(activities.SearchTerm) ? "" : activities.SearchTerm;
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@RowsPerPage", activities.RowsPerPage),
                    new SqlParameter("@PageIndex", activities.PageIndex),
                    new SqlParameter("@WorkFlowId", activities.WorkFlowId),
                    new SqlParameter("@WorkFlowStepId", activities.WorkFlowStepId),
                    new SqlParameter("@AssignedTo", activities.AssignedTo),
                    new SqlParameter("@PriorityStatus", (object)activities.PriorityStatus ?? DBNull.Value),
                    new SqlParameter("@ExpectedFromDate", activities.ExpectedFromDate),
                    new SqlParameter("@ExpectedToDate", activities.ExpectedToDate),
                    new SqlParameter("@SearchTerm",  activities.SearchTerm)
                };
                var result = _context.Set<spGetActivitiesResponseDTO>()
                    .FromSqlRaw("spGetActivities @RowsPerPage, @PageIndex, @WorkFlowId, @WorkFlowStepId, @AssignedTo, @ExpectedFromDate, @ExpectedToDate, @PriorityStatus, @SearchTerm", parameters.ToArray())
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public List<spGetTimelineResponseDTO> GetspTimelineByFilterAsync(spGetTimelineRequestDTO timelines)
        {
            try
            {
                var defFromDt = DateTime.Now.Date;
                var defToDt = DateTime.Now.Date.AddHours(23).AddMinutes(59);
                timelines.RowsPerPage = timelines.RowsPerPage <= 0 ? 100 : timelines.RowsPerPage;
                timelines.PageIndex = timelines.PageIndex < 0 ? 0 : timelines.PageIndex;
                timelines.StartDate = timelines.StartDate == DateTime.MinValue ? defFromDt : timelines.StartDate;
                timelines.EndDate = timelines.EndDate == DateTime.MinValue ? defToDt : timelines.EndDate;
                timelines.SearchTerm = string.IsNullOrEmpty(timelines.SearchTerm) ? "" : timelines.SearchTerm;
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@RowsPerPage", timelines.RowsPerPage),
                    new SqlParameter("@PageIndex", timelines.PageIndex),
                    new SqlParameter("@StartDate", timelines.StartDate),
                    new SqlParameter("@EndDate", timelines.EndDate),
                    new SqlParameter("@WorkFlowStepId", (object)timelines.WorkFlowStepId ?? DBNull.Value),
                    new SqlParameter("@AssignedTo", (object)timelines.AssignedTo ?? DBNull.Value),
                    new SqlParameter("@SearchTerm",  timelines.SearchTerm)
                };
                var result = _context.Set<spGetTimelineResponseDTO>()
                    .FromSqlRaw("spGetTimeline @RowsPerPage, @PageIndex, @StartDate, @EndDate, @WorkFlowStepId, @AssignedTo, @SearchTerm", parameters.ToArray())
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<spGetEmployeeBookingSummaryResponseDTO> GetEmployeeBookingSummaryAsync(spGetEmployeeBookingSummaryRequestDTO request)
        {
            try
            {
                var defFromDt = DateTime.Now.Date;
                var defToDt = DateTime.Now.Date.AddHours(23).AddMinutes(59);
                request.StartDate = request.StartDate == DateTime.MinValue ? defFromDt : request.StartDate;
                request.EndDate = request.EndDate == DateTime.MinValue ? defToDt : request.EndDate;


                var parameters = new List<SqlParameter>
        {
            new SqlParameter("@StartDate", request.StartDate),
            new SqlParameter("@EndDate", request.EndDate)
        };

                var result = _context.Set<spGetEmployeeBookingSummaryResponseDTO>()
                    .FromSqlRaw("spGetEmployeeBookingSummary @StartDate, @EndDate", parameters.ToArray())
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public int? GetParentUserIdByEmployeeId(int employeeId)
        {
            var parentUserId = _context.Employees
                .Where(e => e.Id == employeeId)
                .Select(e => e.ParentUserId)
                .FirstOrDefault();

            return parentUserId;
        }


        public List<int?> GetParentUserIdsByUserIds(AttendanceApprovalRequestDTO attendances)
        {
            var parentUserIds = _context.Employees
                .Where(e => attendances.UserIds.Contains(e.Id))
                .Select(e => e.ParentUserId)
                .ToList();

            return parentUserIds;
        }

        public async Task RegisterNewEmployeeAsync(List<Employee> employee)
        {
            foreach (var entity in employee)
            {
                entity.IsActive = true;
                entity.CreatedDate = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;
                entity.IsDeleted = false;
                entity.EmployeeNumber = entity.EmployeeNumber;

                await (_context as LeadTrackerContext).Employees.AddAsync(entity).ConfigureAwait(false);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task CreateEducation(Education education)
        {
            education.IsActive = true;
            education.CreatedDate = DateTime.Now;
            education.ModifiedDate = DateTime.Now;
            education.IsDeleted = false;

            var previousEducations = _context.Set<Education>()
               .Where(t => t.EmployeeId == education.EmployeeId)
               .ToList();

            await (_context as LeadTrackerContext).Educations.AddAsync(education).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task CreateBankDetail(BankDetail bankDetail)
        {
            bankDetail.IsActive = true;
            bankDetail.CreatedDate = DateTime.Now;
            bankDetail.ModifiedDate = DateTime.Now;
            bankDetail.IsDeleted = false;

            var previousBankDetails = _context.Set<Education>()
               .Where(t => t.EmployeeId == bankDetail.EmployeeId)
               .ToList();

            await (_context as LeadTrackerContext).BankDetails.AddAsync(bankDetail).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Education> GetEducationByEmployeeIdAsync(int id)
        {
            return await _context.Educations
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(e => e.EmployeeId == id)
                .ConfigureAwait(false);
        }

        public async Task<BankDetail> GetBankDetailByEmployeeIdAsync(int id)
        {
            return await _context.BankDetails
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(e => e.EmployeeId == id)
                .ConfigureAwait(false); ;
        }


        public List<spParentDTO> GetEmployeeAndParentByUserIdAsync(int EmployeeId)
        {

            var result = new List<spParentDTO>();

            var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@EmployeeId", EmployeeId)

                };

            result = _context.Set<spParentDTO>().FromSqlRaw("GetEmployeeHierarchy @EmployeeId", parameters.ToArray()).ToList();

            return result;

        }

        public async Task<string> GetEmployeeNameByIdAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            return employee?.Name;
        }


        public async Task<List<int>> GetAllEmployeeIdsAsync()
        {
            var employeeIds = await _context.Employees
                                        .Select(e => e.Id)
                                        .ToListAsync();

            return employeeIds;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task<string> GetUserNameByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee?.Name;
        }
    }
}
