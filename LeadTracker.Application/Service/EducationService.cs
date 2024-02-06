using AutoMapper;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationrepository;
        private readonly IMapper _mappingProfile;


        public EducationService(IMapper mappingProfile, IEducationRepository educationService)
        {
            _mappingProfile = mappingProfile;
            _educationrepository = educationService;

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

        //public async Task RegisterEmployeeEducation(NewEducationDTO education, int userId)
        //{
        //    var educ = new List<Education>();
        //    educ.Add(new Education()
        //    {
        //        Sscpercentage = education.Sscpercentage,
        //        SscyearOfPassing = education.SscyearOfPassing,
        //        Hscpercentage = education.Hscpercentage,
        //        HscyearOfPassing = education.HscyearOfPassing,
        //        GraduationType = education.GraduationType,
        //        GraduationPercentage = education.GraduationPercentage,
        //        GraduationYearOfPassing = education.GraduationYearOfPassing,
        //        //EmployeeId = education.EmployeeId,
        //        Document = null,
        //        CreatedBy = userId,
        //        IsActive = true,
        //        IsDeleted = false,
        //        CreatedDate = DateTime.Now,
        //        ModifiedDate = DateTime.Now,
        //        ModifiedBy = userId,
        //    });

        //    if (education.Files != null)
        //    {
        //        var fileNames = new List<string>();

        //        foreach (var file in education.Files)
        //        {
        //            var outputFile = await WriteFile(file/*, education.Employee.Name*/);
        //            if (!string.IsNullOrEmpty(outputFile))
        //            {
        //                fileNames.Add(outputFile);
        //            }
        //        }
        //        educ[0].Document = string.Join(", ", fileNames);
        //    }
        //    await _educationrepository.RegisterEmployeeEducationAsync(educ).ConfigureAwait(false);
        //}

        //public async Task RegisterEmployeeBankDetail(NewBankDetailDTO bankDetail, int userId)
        //{
        //    var banks = new List<BankDetail>();

        //    banks.Add(new BankDetail()
        //    {
        //        BankName = bankDetail.BankName,
        //        Ifsccode = bankDetail.Ifsccode,
        //        AccountNo = bankDetail.AccountNo,
        //        AadharCardNumber = bankDetail.AadharCardNumber,
        //        PancardNumber = bankDetail.PancardNumber,
        //        MobileNumber = bankDetail.MobileNumber,
        //        Document = null,
        //        //EmployeeId = bankDetail.EmployeeId,
        //        CreatedBy = userId,
        //        IsActive = true,
        //        IsDeleted = false,
        //        CreatedDate = DateTime.Now,
        //        ModifiedDate = DateTime.Now,
        //        ModifiedBy = userId,
        //    });
        //    if (bankDetail.Files != null)
        //    {
        //        var fileNames = new List<string>();

        //        foreach (var file in bankDetail.Files)
        //        {
        //            var outputFile = await WriteFile(file/*, bankDetail.Employee.Name*/);
        //            if (!string.IsNullOrEmpty(outputFile))
        //            {

        //                fileNames.Add(outputFile);
        //            }
        //        }
        //        banks[0].Document = string.Join(", ", fileNames);
        //    }
        //    await _educationrepository.RegisterEmployeeBankDetailAsync(banks).ConfigureAwait(false);
        //}

        public async Task<EducationDTO> UpdateEmployeeEducation(int employeeId, NewEducationDTO education, int userId)
        {
            var existingEducation = await _educationrepository.GetEducationByEmployeeIdAsync(employeeId).ConfigureAwait(false);

            if (existingEducation != null)
            {
                existingEducation.EmployeeId = employeeId;
                existingEducation.Sscpercentage = education.Sscpercentage;
                existingEducation.SscyearOfPassing = education.SscyearOfPassing;
                existingEducation.Hscpercentage = education.Hscpercentage;
                existingEducation.HscyearOfPassing = education.HscyearOfPassing;
                existingEducation.GraduationType = education.GraduationType;
                existingEducation.GraduationPercentage = education.GraduationPercentage;
                existingEducation.GraduationYearOfPassing = education.GraduationYearOfPassing;
                //existingEducation.Document = null;
                existingEducation.ModifiedDate = DateTime.Now;
                existingEducation.ModifiedBy = userId;

                if (education.Files != null)
                {
                    var fileNames = new List<string>();

                    foreach (var file in education.Files)
                    {
                        var outputFile = await WriteFiles(file, existingEducation.Employee.Name);
                        if (!string.IsNullOrEmpty(outputFile))
                        {
                            fileNames.Add(outputFile);
                        }
                    }
                    existingEducation.Document = string.Join(", ", fileNames);
                }
                await _educationrepository.UpdateEducationAsync(existingEducation).ConfigureAwait(false);
            }
            var educationDTO = new EducationDTO
            {
                EmployeeId = existingEducation.EmployeeId,
                Sscpercentage = existingEducation.Sscpercentage,
                SscyearOfPassing = existingEducation.SscyearOfPassing,
                Hscpercentage = existingEducation.Hscpercentage,
                HscyearOfPassing = existingEducation.HscyearOfPassing,
                GraduationType = existingEducation.GraduationType,
                GraduationPercentage = existingEducation.GraduationPercentage,
                GraduationYearOfPassing = existingEducation.GraduationYearOfPassing,
                Document = existingEducation.Document,
                ModifiedDate = DateTime.Now,
                ModifiedBy = userId
            };
            return educationDTO;
        }


        public async Task<BankDetailDTO> UpdateEmployeeBankDetail(int employeeId, NewBankDetailDTO bankDetail, int userId)
        {
            var existingBankDetail = await _educationrepository.GetBankDetailByEmployeeIdAsync(employeeId).ConfigureAwait(false);

            if (existingBankDetail != null)
            {
                existingBankDetail.EmployeeId = employeeId;
                existingBankDetail.BankName = bankDetail.BankName;
                existingBankDetail.Ifsccode = bankDetail.Ifsccode;
                existingBankDetail.AccountNo = bankDetail.AccountNo;
                existingBankDetail.AadharCardNumber = bankDetail.AadharCardNumber;
                existingBankDetail.PancardNumber = bankDetail.PancardNumber;
                existingBankDetail.MobileNumber = bankDetail.MobileNumber;
                existingBankDetail.ModifiedDate = DateTime.Now;
                existingBankDetail.ModifiedBy = userId;

                if (bankDetail.Files != null)
                {
                    var fileNames = new List<string>();

                    foreach (var file in bankDetail.Files)
                    {

                        var outputFile = await WriteFiles(file, existingBankDetail.Employee.Name);
                        if (!string.IsNullOrEmpty(outputFile))
                        {
                            fileNames.Add(outputFile);
                        }
                    }
                    existingBankDetail.Document = string.Join(", ", fileNames);
                }
                await _educationrepository.UpdateBankDetailAsync(existingBankDetail).ConfigureAwait(false);
            }
            var bankDetailDTO = new BankDetailDTO
            {
                EmployeeId = existingBankDetail.EmployeeId,
                BankName = existingBankDetail.BankName,
                Ifsccode = existingBankDetail.Ifsccode,
                AccountNo = existingBankDetail.AccountNo,
                AadharCardNumber = existingBankDetail.AadharCardNumber,
                PancardNumber = existingBankDetail.PancardNumber,
                MobileNumber = existingBankDetail.MobileNumber,
                Document = existingBankDetail.Document,
                ModifiedDate = DateTime.Now,
                ModifiedBy = userId
            };

            return bankDetailDTO;
        }

    }

}
