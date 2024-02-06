using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Extension;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LeadTracker.BusinessLayer.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentrepository;
        private readonly ILogger<DocumentService> _logger;
        private readonly IEmployeeRepository _employeerepository;
        private readonly INotificationService _notificationService;
        private readonly IWorkFlowStepRepository _workFlowStepRepository;
        private readonly ILeadRepository _leadRepository;
        private readonly IVisitTrackingRepository _visitTrackingRepository;


        public DocumentService(IDocumentRepository documentRepository, ILogger<DocumentService> logger, IEmployeeRepository employeerepository, INotificationService notificationService, IWorkFlowStepRepository workFlowStepRepository, ILeadRepository leadRepository, IVisitTrackingRepository visitTrackingRepository
)
        {
            _documentrepository = documentRepository;
            _logger = logger;
            _employeerepository = employeerepository;
            _notificationService = notificationService;
            _workFlowStepRepository = workFlowStepRepository;
            _leadRepository = leadRepository;
            _visitTrackingRepository = visitTrackingRepository;


        }

        public async Task CreateDocument(int userId, int orgId, DocumentDTO document)
        {
            var docs = new List<Document>();
            foreach (var doc in document.Files)
            {
                var outputFile = await WriteFile(doc);
                if (!string.IsNullOrEmpty(outputFile))
                {
                    docs.Add(new Document()
                    {
                        Comment = document.Comment,
                        EnquiryId = document.EnquiryId,
                        Location = outputFile,
                        ModuleType = document.ModuleType,
                        OrgId = orgId,
                        UserId = userId,
                        WorkFlowId = document.WorkFlowId,
                        WorkFlowStepId = document.WorkFlowStepId,
                        TrackerId = document.TrackerId,
                    });
                }
            }
            await _documentrepository.CreateAllAsync(docs).ConfigureAwait(false);
        }


        public async Task InsertStatus(StatusDTO status, int orgId, int userId)
        {
            int assignedTo = status.NextWorkFlowStepId == 5 || status.NextWorkFlowStepId == 6 ? 3 : userId;

            if (status.Files != null && status.Files.Count > 0)
            {
                var documents = new List<Document>();

                foreach (var doc in status.Files)
                {
                    var outputFile = await WriteFile(doc);
                    if (!string.IsNullOrEmpty(outputFile))
                    {

                        var document = new Document
                        {
                            EnquiryId = status.EnquiryId,
                            TrackerId = status.TrackerId,
                            ModuleType = status.ModuleType,
                            Location = outputFile,
                            Comment = status.Comment,
                            WorkFlowId = status.WorkFlowId,
                            WorkFlowStepId = status.CurrentWorkFlowStepId,
                            OrgId = orgId,
                            UserId = userId
                        };

                        documents.Add(document);
                    }
                }


                await _documentrepository.CreateAllAsync(documents).ConfigureAwait(false);
            }


            var tracker = new Tracker
            {
                EnquiryId = status.EnquiryId,
                VisitExpectedDate = status.VisitExpectedDate,
                CodeId = status.ModuleType,
                //Remark = status.Comment,
                Date = DateTime.UtcNow,
                VisitExpected = null,
                VisitedProjectId = status.VisitedProjectId,
                VisitRemark = null,
                AssignedTo = assignedTo,
                WorkFlowId = status.WorkFlowId,
                WorkFlowStepId = status.NextWorkFlowStepId,
                IsStepCompleted = false,
                OrgId = orgId,
                PriorityStatus = status.PriorityStatus,
                Requirement = status.Requirement,
                Budget = status.Budget,
                Purpose = status.Purpose,
                CompanyPercentage = status.CompanyPercentage,
                EmployeePercentage = status.EmployeePercentage,
                RegistrationValue = status.RegistrationValue,
                TotalIncentive = status.TotalIncentive,
                TDS = status.TDS
            };


            var existingLead = await _leadRepository.GetByIdAsync(status.EnquiryId ?? 0);

            if (existingLead != null)
            {
                existingLead.Name = status.Name;
                existingLead.FinalRemark = status.Comment;
                existingLead.Requirement = status.Requirement;
                existingLead.Budget = status.Budget;
                existingLead.TrackerFlowStepId = status.NextWorkFlowStepId;
                existingLead.AssignedTo = assignedTo;
                existingLead.ModifiedDate = DateTime.UtcNow;
                existingLead.ModifiedBy = userId;
                existingLead.Purpose = status.Purpose;

                await _leadRepository.UpdateAsync(existingLead);

            }
            var visitTracking = new VisitTracking
            {
                //StartDateTime = DateTime.Now,
                WorkFlowStepId = status.CurrentWorkFlowStepId,
                UserId = userId,
                EnquiryId = status.EnquiryId,
                ProjectId = status.VisitedProjectId,
                CreatedBy = userId,
                ModifiedBy = userId,
                VisitStatus = "Pending",
                Status = true
            };
            await _visitTrackingRepository.CreateVisitTracking(visitTracking);


            if (tracker.WorkFlowStepId == 4)
            {
                //var parentName = await _employeerepository.GetEmployeeNameByIdAsync(userId);
                var assignedToName = await _employeerepository.GetEmployeeNameByIdAsync(tracker.AssignedTo ?? 0);

                string ModuleName = "Work flow";

                //string text = $"Hello, {assignedToName} have a Booking!!!";

                await _notificationService.NotificationForBookingAsync(ModuleName, userId, assignedToName);


            }

            if (tracker.WorkFlowStepId == 5 || tracker.WorkFlowStepId == 6)
            {
                string moduleName = "Rejected";
                var hrName = await _employeerepository.GetEmployeeNameByIdAsync(3);
                var userName = await _employeerepository.GetEmployeeNameByIdAsync(userId);



                var currentStepName = await _workFlowStepRepository.GetWorkFlowStepNameById(status.CurrentWorkFlowStepId ?? 0);
                var NextStepName = await _workFlowStepRepository.GetWorkFlowStepNameById(status.NextWorkFlowStepId ?? 0);


                string textForHR = $"Hello {hrName}, {userName} had a {currentStepName} and now Added in {NextStepName}";

                await _notificationService.CreateNotificationForUser(3, textForHR, moduleName, userId);

            }


            await _documentrepository.CreateTracker(tracker, status);

            if (status.Files != null)
            {
                foreach (var file in status.Files)
                {
                    await WriteFile(file);
                }
            }
        }

        public async Task<string> WriteFile(IFormFile file)
        {
            string filename = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var outputFile = Path.Combine("Upload\\Files\\" + file.FileName);
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
        public async Task<string> GetDocumentType(string documentPath)
        {
            string extension = Path.GetExtension(documentPath)?.ToLowerInvariant();

            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".svg":
                case ".svg+xml":
                    return "Image";
                case ".pdf":
                    return "PDF";
                case ".xlsx":
                case ".xls":
                    return "Excel";
                default:
                    return "Unknown";
            }
        }
        public async Task<string> GetContentType(string documentPath)
        {
            switch (Path.GetExtension(documentPath).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";

                case ".pdf":
                    return "application/pdf";
                case ".doc":
                case ".docx":
                    return "application/msword";
                case ".xls":
                case ".xlsx":
                    return "application/vnd.ms-excel";

                default:
                    return "application/octet-stream";
            }
        }

    }
}
