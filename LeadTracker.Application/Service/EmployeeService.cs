using AutoMapper;
using LeadTracker.API;
using LeadTracker.API.Entities;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        private readonly IEducationRepository _educationrepository;
        private readonly IMapper _mappingProfile;
        private readonly IRoleRepository _roleRepository;
        private readonly LeadTrackerContext _context;
        private readonly INotificationService _notificationService;




        public EmployeeService(IMapper mappingProfile, IEmployeeRepository employeeService, IRoleRepository roleRepository, IEducationRepository educationService, LeadTrackerContext context, INotificationService notificationService)
        {
            _mappingProfile = mappingProfile;
            _employeerepository = employeeService;
            _roleRepository = roleRepository;
            _educationrepository = educationService;
            _context = context;
            _notificationService = notificationService;

        }

        public async Task<string> WriteFiles(IFormFile file, string employeeName)
        {
            string filename = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), $"Upload\\EmployeeDocument\\{employeeName}");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var outputFile = Path.Combine($"Upload\\EmployeeDocument\\{employeeName}\\" + file.FileName);
                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), outputFile);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return outputFile;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<string> GenerateEmployeeNumber(int orgId)
        {
            var configKey = "Increase_Employee_Number";

            var systemConfig = await _context.SystemConfigurations
                                        .FirstOrDefaultAsync(c => c.OrgId == orgId && c.KeyDetail == configKey)
                                        .ConfigureAwait(false);
            int currentEmployeeNumber = +1;

            if (systemConfig != null && int.TryParse(systemConfig.Value, out currentEmployeeNumber))
            {
                currentEmployeeNumber++;

                await UpdateEmployeeNumberInConfiguration(orgId, configKey, currentEmployeeNumber).ConfigureAwait(false);

                systemConfig.Value = currentEmployeeNumber.ToString();
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return $"TR-{currentEmployeeNumber}";
            }
            //else
            //{
            //    await UpdateEmployeeNumberInConfiguration(orgId, configKey, 1).ConfigureAwait(false);

            //    return "Emp-00";
            //}
            return null;
        }

        private async Task UpdateEmployeeNumberInConfiguration(int orgId, string configKey, int newEmployeeNumber)
        {
            var systemConfig = await _context.SystemConfigurations
                                                .FirstOrDefaultAsync(c => c.OrgId == orgId && c.KeyDetail == configKey)
                                                .ConfigureAwait(false);

            if (systemConfig != null)
            {
                systemConfig.Value = newEmployeeNumber.ToString();
            }
            else
            {
                var newConfigEntry = new SystemConfiguration
                {
                    OrgId = orgId,
                    KeyDetail = configKey,
                    Value = newEmployeeNumber.ToString()
                };

                _context.SystemConfigurations.Update(newConfigEntry);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<EmployeeDTO> RegisterEmployee(NewEmployeeDTO employee, int orgId, int userId)
        {
            var emps = new List<Employee>();

            var employeeNumber = await GenerateEmployeeNumber(orgId);
            //emps[0].EmployeeNumber = employeeNumber;

            emps.Add(new Employee()
            {
                Name = employee.Name,
                EmailId = employee.EmailId,
                UserName = employee.UserName,
                Dob = employee.Dob,
                BioMatricCode = employee.BioMatricCode,
                Doj = employee.Doj,
                Reference = employee.Reference,
                Designation = employee.Designation,
                FatherNameOfEmployee = employee.FatherNameOfEmployee,
                AlternateNo = employee.AlternateNo,
                CorrespondanceAddressDetails = employee.CorrespondanceAddressDetails,
                CorrespondancePlace = employee.CorrespondancePlace,
                CorrespondancePincode = employee.CorrespondancePincode,
                PermanentAdressDetails = employee.PermanentAdressDetails,
                PermanentPlace = employee.PermanentPlace,
                PermanentPincode = employee.PermanentPincode,
                Password = "1234",
                Mpin = "1234",
                Mobile = employee.Mobile,
                ParentUserId = employee.ParentUserId,
                AadharCardNumber = employee.AadharCardNumber,
                PancardNumber = employee.PancardNumber,
                Salary = employee.Salary,
                EmployeeNumber = employeeNumber,
                Document = null,
                OrgId = orgId,
                CreatedBy = userId,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = userId,
                Gender = employee.Gender,
                RoleId = employee.RoleId,
                ProfilePhoto = null
            });

            if (employee.Files != null)
            {
                var fileNames = new List<string>();

                foreach (var file in employee.Files)
                {
                    var outputFile = await WriteFiles(file, employee.Name);
                    if (!string.IsNullOrEmpty(outputFile))
                    {
                        fileNames.Add(outputFile);
                        //emps[0].Document = outputFile;
                    }
                }
                emps[0].Document = string.Join(", ", fileNames);
            }
            await _employeerepository.RegisterNewEmployeeAsync(emps).ConfigureAwait(false);

            var generatedEmployeeId = emps[0].Id;

            var employeeDTO = new EmployeeDTO
            {
                Id = generatedEmployeeId,
                Name = employee.Name,
                EmailId = employee.EmailId,
                UserName = employee.UserName,
                Dob = employee.Dob,
                BioMatricCode = employee.BioMatricCode,
                Doj = employee.Doj,
                Reference = employee.Reference,
                Designation = employee.Designation,
                FatherNameOfEmployee = employee.FatherNameOfEmployee,
                AlternateNo = employee.AlternateNo,
                CorrespondanceAddressDetails = employee.CorrespondanceAddressDetails,
                CorrespondancePlace = employee.CorrespondancePlace,
                CorrespondancePincode = employee.CorrespondancePincode,
                PermanentAdressDetails = employee.PermanentAdressDetails,
                PermanentPlace = employee.PermanentPlace,
                PermanentPincode = employee.PermanentPincode,
                Password = "1234",
                Mpin = "1234",
                Mobile = employee.Mobile,
                ParentUserId = employee.ParentUserId,
                AadharCardNumber = employee.AadharCardNumber,
                Salary = employee.Salary,
                PancardNumber = employee.PancardNumber,
                EmployeeNumber = employeeNumber,
                OrgId = orgId,
                CreatedBy = userId,
                ModifiedBy = userId,
                Gender = employee.Gender,
                RoleId = employee.RoleId,
            };

            var education = new Education
            {
                EmployeeId = generatedEmployeeId,
                Sscpercentage = null,
                SscyearOfPassing = null,
                Hscpercentage = null,
                HscyearOfPassing = null,
                GraduationType = null,
                GraduationPercentage = null,
                GraduationYearOfPassing = null,
                Document = null,
                CreatedBy = userId,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = userId,
            };
            await _employeerepository.CreateEducation(education);

            var bankDetail = new BankDetail
            {
                EmployeeId = generatedEmployeeId,
                BankName = null,
                Ifsccode = null,
                AccountNo = null,
                AadharCardNumber = employee.AadharCardNumber,
                PancardNumber = employee.PancardNumber,
                MobileNumber = employee.Mobile,
                Document = null,
                CreatedBy = userId,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = userId,
            };
            await _employeerepository.CreateBankDetail(bankDetail);

            if (employee.Files != null)
            {
                foreach (var file in employee.Files)
                {
                    await WriteFiles(file, employee.Name);
                }
            }

            var parentName = await _employeerepository.GetEmployeeNameByIdAsync(userId);
            var assignedToName = await _employeerepository.GetEmployeeNameByIdAsync(2);
            var roleName = await _roleRepository.GetRoleNameByIdAsync(employee.RoleId);
            //var newEmployeeName = await _employeerepository.GetEmployeeNameByIdAsync(employee.);
            int assignedTo = 2;

            string ModuleName = "Employee Registration";
            string Text = $"Hello {assignedToName}, {parentName} have Registered a New Employee for position of {roleName}";

            await _notificationService.CreateNotificationForUser(assignedTo, Text, ModuleName, userId);


            return employeeDTO;
        }

        public async Task<Employee> EditEmployeeAsync(int id, NewEmployeeDTO updatedEmployee)
        {
            var existingEmployee = await _employeerepository.GetByIdAsync(id);

            if (existingEmployee != null)
            {
                existingEmployee.Name = updatedEmployee.Name;
                existingEmployee.EmailId = updatedEmployee.EmailId;
                existingEmployee.UserName = updatedEmployee.UserName;
                existingEmployee.Mobile = updatedEmployee.Mobile;
                existingEmployee.ParentUserId = updatedEmployee.ParentUserId;
                existingEmployee.AadharCardNumber = updatedEmployee.AadharCardNumber;
                existingEmployee.Salary = updatedEmployee.Salary;
                existingEmployee.PancardNumber = updatedEmployee.PancardNumber;
                existingEmployee.BioMatricCode = updatedEmployee.BioMatricCode;
                existingEmployee.Reference = updatedEmployee.Reference;
                existingEmployee.Designation = updatedEmployee.Designation;
                existingEmployee.FatherNameOfEmployee = updatedEmployee.FatherNameOfEmployee;
                existingEmployee.AlternateNo = updatedEmployee.AlternateNo;
                existingEmployee.CorrespondanceAddressDetails = updatedEmployee.CorrespondanceAddressDetails;
                existingEmployee.CorrespondancePlace = updatedEmployee.CorrespondancePlace;
                existingEmployee.CorrespondancePincode = updatedEmployee.CorrespondancePincode;
                existingEmployee.PermanentAdressDetails = updatedEmployee.PermanentAdressDetails;
                existingEmployee.PermanentPlace = updatedEmployee.PermanentPlace;
                existingEmployee.PermanentPincode = updatedEmployee.PermanentPincode;
                existingEmployee.Dob = updatedEmployee.Dob;
                existingEmployee.Doj = updatedEmployee.Doj;
                existingEmployee.ModifiedDate = DateTime.Now;
                existingEmployee.Gender = updatedEmployee.Gender;
                existingEmployee.RoleId = updatedEmployee.RoleId;

                if (updatedEmployee.ProfilePhoto != null /*&& updatedEmployee.ProfilePhoto.Any()*/)
                {
                    var profilePhoto = updatedEmployee.ProfilePhoto.First();

                    var profilePhotoOutput = await WriteFiles(profilePhoto, existingEmployee.Name);
                    if (!string.IsNullOrEmpty(profilePhotoOutput))
                    {
                        existingEmployee.ProfilePhoto = profilePhotoOutput;
                    }
                }

                if (updatedEmployee.Files != null)
                {
                    var fileNames = new List<string>();

                    foreach (var file in updatedEmployee.Files)
                    {
                        //var employeeName = existingEmployee.Name;  
                        var outputFile = await WriteFiles(file, existingEmployee.Name);
                        if (!string.IsNullOrEmpty(outputFile))
                        {
                            //existingEmployee.Document = outputFile;
                            fileNames.Add(outputFile);
                        }
                    }
                    existingEmployee.Document = string.Join(", ", fileNames);
                }
                await _employeerepository.UpdateAsync(existingEmployee);

                return existingEmployee;
            }
            return null;
        }

        public async Task<EmployeeDetailsDTO> GetEmployeeDetailsByIdAsync(int id)
        {
            var employee = await _employeerepository.GetByIdAsync(id);
            var roleName = await _roleRepository.GetByIdAsync(employee.RoleId ?? 0);
            var employeeDTO = _mappingProfile.Map<EmployeeDTO>(employee);
            //employeeDTO.RoleName = roleName.Name;

            var education = await _employeerepository.GetEducationByEmployeeIdAsync(id);
            var educationDTO = _mappingProfile.Map<EducationDTO>(education);

            var bankDetail = await _employeerepository.GetBankDetailByEmployeeIdAsync(id);
            var bankDetailDTO = _mappingProfile.Map<BankDetailDTO>(bankDetail);

            var employeeDetails = new EmployeeDetailsDTO
            {
                Employees = employeeDTO,
                Educations = educationDTO,
                BankDetails = bankDetailDTO
            };
            return employeeDetails;
        }


        public async Task CreateEmployee(EmployeeDTO employee)
        {
            var empl = _mappingProfile.Map<Employee>(employee);
            await _employeerepository.CreateAsync(empl).ConfigureAwait(false);
        }


        //public async Task RegisterEmployee(NewEmployeeDTO employee, int orgId, int userId)
        //{
        //    Employee newEmployee = new Employee
        //    {
        //        Name = employee.Name,
        //        EmailId = employee.EmailId,
        //        UserName = employee.UserName,
        //        Password = "1234",
        //        Mpin = "1234",
        //        Mobile = employee.Mobile,
        //        ParentUserId = employee.ParentUserId,
        //        OrgId = orgId,
        //        CreatedBy = userId, 
        //        IsActive = true,
        //        IsDeleted = false,
        //        CreatedDate = DateTime.Now,
        //        ModifiedDate = DateTime.Now,
        //        ModifiedBy= userId,
        //        Gender = employee.Gender,
        //        RoleId = employee.RoleId,
        //        ProfilePhoto = null
        //    };

        //    await _employeerepository.CreateAsync(newEmployee).ConfigureAwait(false);
        //}


        //public async Task<Employee> EditEmployeeAsync(int id, NewEmployeeDTO updatedEmployee)
        //{
        //    var existingEmployee = await _employeerepository.GetByIdAsync(id);

        //    if (existingEmployee != null)
        //    {
        //        existingEmployee.Name = updatedEmployee.Name;
        //        existingEmployee.EmailId = updatedEmployee.EmailId;
        //        existingEmployee.UserName = updatedEmployee.UserName;
        //        existingEmployee.Mobile = updatedEmployee.Mobile;
        //        existingEmployee.ParentUserId = updatedEmployee.ParentUserId;
        //        existingEmployee.ModifiedDate = DateTime.Now;
        //        existingEmployee.Gender = updatedEmployee.Gender;
        //        existingEmployee.RoleId = updatedEmployee.RoleId;


        //        await _employeerepository.UpdateAsync(existingEmployee);

        //        return existingEmployee;
        //    }

        //    return null;
        //}


        //        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        //        {
        //            var employee = await _employeerepository.GetByIdAsync(id)
        //;

        //            var roleName = await _roleRepository.GetByIdAsync(employee.RoleId ?? 0);


        //            var employeeDTO = _mappingProfile.Map<EmployeeDTO>(employee);

        //            employeeDTO.RoleName = roleName.Name;

        //            return employeeDTO;
        //        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeeAsync()
        {
            var employees = await _employeerepository.GetAllAsync();

            var filteredEmployees = employees.Where(e => e.IsActive == true && e.IsDeleted == false).ToList();

            var employeesDTO = _mappingProfile.Map<List<EmployeeDTO>>(filteredEmployees);

            return employeesDTO.ToList();
        }




        public async Task UpdateEmployeeAsync(int id, EmployeeDTO employee)
        {
            var existingEmployee = await _employeerepository.GetByIdAsync(id);


            _mappingProfile.Map(employee, existingEmployee);


            await _employeerepository.UpdateAsync(existingEmployee);

           
        }

       
        public async Task<EmployeeDTO> DeleteEmployeeAsync(int id, int userId)
        {
            var employee = await _employeerepository.GetByIdAsync(id);

            if (employee != null)
            {
                await _employeerepository.DeleteAsync(id);
            }

            var assignedToUserIds = new List<int> { 2, 3, 4 }; // Add the user IDs you want to assign notifications to

            var roleName = await _roleRepository.GetRoleNameByIdAsync(employee.RoleId);
            var employeeName = await _employeerepository.GetUserNameByIdAsync(id);
            var parentName = await _employeerepository.GetEmployeeNameByIdAsync(userId);

            foreach (var assignedTo in assignedToUserIds)
            {
                var assignedToName = await _employeerepository.GetEmployeeNameByIdAsync(assignedTo);

                string moduleName = "Delete Employee";
                string text = $"Hello {assignedToName},{parentName} has Deleted {employeeName}'s ({roleName}) Profile.";

                await _notificationService.CreateNotificationForUser(assignedTo, text, moduleName, userId);
            }

            return null;
        }


        public async Task<List<spParentAndChildrenDTO>> GetspEmployeesByUserIdAsync(int userId, int orgId)
        {
            var employees = _employeerepository.GetEmployeesByUserIdAsync(userId, orgId);

            if (employees == null)
            {
                return null;
            }

            var Employees = _mappingProfile.Map<List<spParentAndChildrenDTO>>(employees).ToList();

            return Employees;
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDTO changePassword)
        {
            return await _employeerepository.ChangePasswordAsync(
                changePassword.Id,
                changePassword.CurrentPassword,
                changePassword.NewPassword
            );
        }


        public async Task<List<spParentDTO>> GetspParentOfUsersAsync()
        {
            var spParents = _employeerepository.GetspParentOfUsersByOrgIdAsync();

            if (spParents == null)
            {
                return null;
            }

            var SpParents = _mappingProfile.Map<List<spParentDTO>>(spParents).ToList();

            return SpParents;
        }

        public async Task<List<spGetActivitiesResponseDTO>> GetspActivitiesAsync(spGetActivitiesRequestDTO activities)
        {
            try
            {
                var spActivities = _employeerepository.GetspActivitiesByFiltersAsync(activities);

                if (spActivities == null)
                {
                    return null;
                }

                var spActivitiesDto = _mappingProfile.Map<List<spGetActivitiesResponseDTO>>(spActivities).ToList();

                return spActivitiesDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<spGetTimelineResponseDTO>> GetTimelineAsync(spGetTimelineRequestDTO timeline)
        {
            try
            {
                var timelines = _employeerepository.GetspTimelineByFilterAsync(timeline);

                if (timelines == null)
                {
                    return null;
                }

                var spTimelineDtos = _mappingProfile.Map<List<spGetTimelineResponseDTO>>(timelines).ToList();

                return spTimelineDtos;
            }

            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<spGetEmployeeBookingSummaryResponseDTO>> GetEmployeeBookingSummary(spGetEmployeeBookingSummaryRequestDTO request)
        {
            try
            {
                var spRequest = _employeerepository.GetEmployeeBookingSummaryAsync(request);

                if (spRequest == null)
                {
                    return null;
                }

                var spRequestDto = _mappingProfile.Map<List<spGetEmployeeBookingSummaryResponseDTO>>(spRequest).ToList();

                return spRequestDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> GetEmployeeStatus(int id)
        {
            var employee = await _employeerepository.GetEmployeeById(id);

            if (employee != null)
            {
                if (employee.IsActive == true)
                {
                    return "Active";
                }
                else if (employee.IsDeleted == true)
                {
                    return "Deleted";
                }
            }
            return null;
        }

    }
}



