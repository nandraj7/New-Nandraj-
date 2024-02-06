using AutoMapper;
using Azure;
using DocuSign.eSign.Model;
using ExcelDataReader;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Core.Extension;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;

namespace LeadTracker.BusinessLayer.Service
{
    public class LeadSourceService : ILeadSourceService
    {
        private readonly ILeadSourceRepository _leadSourceRepository;
        private readonly ILeadRepository _leadRepository;
        private readonly ITrackerRepository _trackerRepository;
        public readonly IConfiguration _configuration;
        public readonly Microsoft.Data.SqlClient.SqlConnection _sqlConnection;
        private readonly IMapper _mappingProfile;
        private readonly LeadTrackerContext _context;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly INotificationService _notificationService;
        private readonly IWorkFlowStepRepository _workFlowStepRepository;


        public LeadSourceService(ILeadSourceRepository leadSourceRepository, ILeadRepository leadRepository, ITrackerRepository trackerRepository, IConfiguration configuration, IMapper mappingProfile, LeadTrackerContext context, IEmployeeRepository employeeRepository, INotificationService notificationService, IWorkFlowStepRepository workFlowStepRepository)
        {
            _configuration = configuration;
            _mappingProfile = mappingProfile;
            _context = context;
            _sqlConnection = new Microsoft.Data.SqlClient.SqlConnection(_configuration["ConnectionOptions:DbConnection"]);
            _employeeRepository = employeeRepository;
            _leadSourceRepository = leadSourceRepository;
            _leadRepository = leadRepository;
            _trackerRepository = trackerRepository;
            _notificationService = notificationService;
            _workFlowStepRepository = workFlowStepRepository;
        }

        public async Task<UploadXMLFileResponse> UploadXMLFile(LeadSourceDTO leadSource, string path)
        {
            UploadXMLFileResponse response = new UploadXMLFileResponse();
            List<ExcelBulkUploadParameter> Parameters = new List<ExcelBulkUploadParameter>();
            DataSet dataSet;
            response.IsSuccess = true;
            response.Message = "Successful";

            try
            {
                var leadSources = new LeadSource();
                {
                    leadSources = new LeadSource()
                    {
                        LeadsSource = leadSource.LeadsSource,
                        LeadSourceProject = leadSource.LeadSourceProject,
                    };
                }


                leadSources.Date = DateTime.Now;
                leadSources.IsActive = true;
                leadSources.CreatedDate = DateTime.Now;
                leadSources.ModifiedDate = DateTime.Now;
                leadSources.IsDeleted = false;
                leadSources.IsProcessed = false;

                if (_sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConnection.OpenAsync();
                }

                if (leadSource.Files.FileName.ToLower().Contains(value: ".xlsx"))
                {
                    FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                    dataSet = reader.AsDataSet(

                       new ExcelDataSetConfiguration()
                       {
                           UseColumnDataType = false,
                           ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                           {
                               UseHeaderRow = true
                           }

                       });
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        ExcelBulkUploadParameter rows = new ExcelBulkUploadParameter();

                        rows.Name = dataSet.Tables[0].Rows[i].ItemArray[0] != null ? Convert.ToString(dataSet.Tables[0].Rows[i].ItemArray[0]) : "-1";
                        rows.MobNo = dataSet.Tables[0].Rows[i].ItemArray[1] != null ? Convert.ToString(dataSet.Tables[0].Rows[i].ItemArray[1]) : "-1";
                        rows.EmailId = dataSet.Tables[0].Rows[i].ItemArray[2] != null ? Convert.ToString(dataSet.Tables[0].Rows[i].ItemArray[2]) : "-1";
                        rows.Requirement = dataSet.Tables[0].Rows[i].ItemArray[3] != null ? Convert.ToString(dataSet.Tables[0].Rows[i].ItemArray[3]) : "-1";
                        rows.Budget = dataSet.Tables[0].Rows[i].ItemArray[4] != null ? Convert.ToString(dataSet.Tables[0].Rows[i].ItemArray[4]) : "-1";
                        rows.Remark = dataSet.Tables[0].Rows[i].ItemArray[5] != null ? Convert.ToString(dataSet.Tables[0].Rows[i].ItemArray[5]) : "-1";
                        Parameters.Add(rows);
                    }
                    stream.Close();

                    if (Parameters.Count > 0)
                    {
                        string SqlQuery = @"INSERT INTO LeadSource
                             (LeadsSource, LeadSourceProject, Name, MobNo, EmailId, Requirement, Budget, Remark, Date, IsActive, CreatedDate, ModifiedDate, IsDeleted, IsProcessed) VALUES 
                             (@LeadsSource, @LeadSourceProject, @Name, @MobNo, @EmailId, @Requirement, @Budget, @Remark, @Date, @IsActive, @CreatedDate, @ModifiedDate, @IsDeleted, @IsProcessed)";

                        foreach (ExcelBulkUploadParameter rows in Parameters)
                        {
                            using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                            {
                                sqlCommand.CommandType = CommandType.Text;
                                sqlCommand.CommandTimeout = 180;
                                sqlCommand.Parameters.AddWithValue("@LeadsSource", leadSource.LeadsSource);
                                sqlCommand.Parameters.AddWithValue("@LeadSourceProject", leadSource.LeadSourceProject);
                                sqlCommand.Parameters.AddWithValue("@Name", rows.Name);
                                sqlCommand.Parameters.AddWithValue("@MobNo", rows.MobNo);
                                sqlCommand.Parameters.AddWithValue("@EmailId", rows.EmailId);
                                sqlCommand.Parameters.AddWithValue("@Requirement", rows.Requirement);
                                sqlCommand.Parameters.AddWithValue("@Budget", rows.Budget);
                                sqlCommand.Parameters.AddWithValue("@Remark", rows.Remark);


                                sqlCommand.Parameters.AddWithValue("@Date", leadSources.Date);
                                sqlCommand.Parameters.AddWithValue("@IsActive", leadSources.IsActive);
                                sqlCommand.Parameters.AddWithValue("@CreatedDate", leadSources.CreatedDate);
                                sqlCommand.Parameters.AddWithValue("@ModifiedDate", leadSources.ModifiedDate);
                                sqlCommand.Parameters.AddWithValue("@IsDeleted", leadSources.IsDeleted);
                                sqlCommand.Parameters.AddWithValue("@IsProcessed", leadSources.IsProcessed);

                                int Status = await sqlCommand.ExecuteNonQueryAsync();
                                if (Status <= 0)
                                {
                                    response.IsSuccess = false;
                                    response.Message = "Query Not Executed";
                                    return response;
                                }
                            }
                        }
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid File";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await _sqlConnection.CloseAsync();
                await _sqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<LeadSourceGetDTO> GetLeadSourceByIdAsync(int id)
        {
            var leadSources = await _leadSourceRepository.GetByIdAsync(id);

            var leadSourceDTO = _mappingProfile.Map<LeadSourceGetDTO>(leadSources);
            return leadSourceDTO;
        }



        public async Task<IEnumerable<LeadSourceGetDTO>> GetLeadSourceByStepAsync(int take, int skip)
        {



            var leadSources = await _leadSourceRepository.GetLeadSourcesAsync(take, skip).ConfigureAwait(false);

            var leadSourceDTO = _mappingProfile.Map<List<LeadSourceGetDTO>>(leadSources);

            var filteredLeadSourceDTO = leadSourceDTO.Where(dto => dto.IsProcessed == false).ToList();

            return filteredLeadSourceDTO;
        }


        public async Task<(List<Lead>, List<Tracker>)> TransferDataAsync(int assignedTo, List<int> leadSourceIds, int orgId, int userId)
        {
            var parentName = await _employeeRepository.GetEmployeeNameByIdAsync(userId);
            var assignedToName = await _employeeRepository.GetEmployeeNameByIdAsync(assignedTo);

            var createdLeads = new List<Lead>();
            var createdTrackers = new List<Tracker>();

            var wFlowId = await _leadSourceRepository.GetWorkFlowIdFromOrgId(orgId).ConfigureAwait(false);

            foreach (int leadSourceId in leadSourceIds)
            {
                var leadSource = await _leadSourceRepository.GetLeadSourceByIdAsync(leadSourceId);

                if (leadSource != null)
                {
                    leadSource.IsProcessed = true;
                    await _leadSourceRepository.UpdateLeadSourceAsync(leadSource);

                    var lead = new Lead
                    {
                        Date = leadSource.Date,
                        LeadSource = leadSource.LeadsSource,
                        LeadSourceProject = leadSource.LeadSourceProject,
                        Name = leadSource.Name,
                        MobNo = leadSource.MobNo,
                        EmailId = leadSource.EmailId,
                        Requirement = leadSource.Requirement,
                        Budget = leadSource.Budget,
                        Purpose = leadSource.Purpose,
                        Description = string.Empty,
                        Status = 0,
                        FinalRemark = string.Empty,
                        EnquiryType = string.Empty,
                        IsActive = true,
                        IsDeleted = false,
                        TrackerFlowStepId = 1,
                        AssignedTo = assignedTo,
                        CreatedDate = DateTime.Now,
                        CreatedBy = 0,
                        ModifiedBy = 0,
                        OrgId = orgId,
                    };

                    var createdLead = await _leadRepository.CreateLeadAsync(lead);

                    var tracker = new Tracker
                    {
                        EnquiryId = createdLead.Id,
                        CodeId = 0,
                        Remark = string.Empty,
                        Date = DateTime.Now,
                        VisitExpected = true,
                        VisitExpectedDate = DateTime.Now,
                        VisitedProjectId = null,
                        VisitRemark = string.Empty,
                        IsActive = true,
                        IsDeleted = false,
                        AssignedTo = assignedTo,
                        WorkFlowId = wFlowId,
                        WorkFlowStepId = 1,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        CreatedBy = 0,
                        ModifiedBy = 0,
                        IsStepCompleted = false,
                        OrgId = orgId,
                        //
                        Requirement = leadSource.Requirement,
                        Budget = leadSource.Budget,
                        Purpose = leadSource.Purpose,
                        //
                        Enquiry = lead,
                    };

                    await _trackerRepository.CreateTrackerByLeadSourceAsync(tracker);

                    createdLeads.Add(createdLead);
                    createdTrackers.Add(tracker);
                }
            }

            int count = leadSourceIds.Count;
            string ModuleName = "Unassigned Leads";
            string Text = $"Hello {assignedToName}, you have {count} new RSVPs assigned by {parentName}";

            await _notificationService.CreateNotificationForUser(assignedTo, Text, ModuleName, userId);

            return (createdLeads, createdTrackers);
        }


        public async Task<List<Tracker>> CreateAndUpdateTrackersAsync(int assignedTo, List<int> trackerIds, int orgId, int userId)
        {
            var wFlowId = await _leadSourceRepository.GetWorkFlowIdFromOrgId(orgId).ConfigureAwait(false);


            var createdTrackers = new List<Tracker>();
            int newWorkflowStepId = 0;

            foreach (int trackerId in trackerIds)
            {
                var existingTracker = await _trackerRepository.GetByIdAsync(trackerId);

                if (existingTracker != null)
                {

                    existingTracker.IsStepCompleted = true;
                    await _trackerRepository.UpdateAsync(existingTracker);

                    var lead = await _leadRepository.GetByIdAsync(existingTracker.EnquiryId ?? 0);


                    //int newWorkflowStepId = 0;

                    if (existingTracker.WorkFlowStepId == 5)
                    {
                        newWorkflowStepId = 1;
                    }
                    else if (existingTracker.WorkFlowStepId == 6)
                    {
                        newWorkflowStepId = 2;
                    }


                    var newTracker = new Tracker
                    {
                        EnquiryId = existingTracker.EnquiryId,
                        CodeId = existingTracker.CodeId,
                        Remark = existingTracker.Remark,
                        Date = existingTracker.Date,
                        VisitExpected = existingTracker.VisitExpected,
                        VisitExpectedDate = existingTracker.VisitExpectedDate,
                        VisitedProjectId = existingTracker.VisitedProjectId,
                        VisitRemark = existingTracker.VisitRemark,
                        IsActive = existingTracker.IsActive,
                        IsDeleted = existingTracker.IsDeleted,
                        AssignedTo = assignedTo,
                        WorkFlowId = wFlowId,
                        WorkFlowStepId = newWorkflowStepId,
                        CreatedDate = existingTracker.CreatedDate,
                        ModifiedDate = DateTime.Now,
                        CreatedBy = existingTracker.CreatedBy,
                        ModifiedBy = userId,
                        IsStepCompleted = false,
                        OrgId = orgId,
                        Requirement = existingTracker.Requirement,
                        Budget = existingTracker.Budget,
                        Purpose = existingTracker.Purpose,
                        //
                        Enquiry = lead,
                        //
                    };

                    await _trackerRepository.CreateTrackerByLeadSourceAsync(newTracker);

                    createdTrackers.Add(newTracker);
                }
            }


            var parentName = await _employeeRepository.GetEmployeeNameByIdAsync(userId);
            var assignedToName = await _employeeRepository.GetEmployeeNameByIdAsync(assignedTo);

            int count = createdTrackers.Count;
            string ModuleName = "Reassigned Data";
            string Text = $"Hello {assignedToName}, you have {count} new records assigned by {parentName}";

            if (newWorkflowStepId == 1)
            {
                var workFlowStepName = await _workFlowStepRepository.GetWorkFlowStepNameByIdAsync(1);
                Text = $"Hello {assignedToName}, you have {count} new {workFlowStepName} records assigned by {parentName}";
            }
            else if (newWorkflowStepId == 2)
            {
                var workFlowStepName = await _workFlowStepRepository.GetWorkFlowStepNameByIdAsync(2);
                Text = $"Hello {assignedToName}, you have {count} new {workFlowStepName} records assigned by {parentName}";
            }

            await _notificationService.CreateNotificationForUser(assignedTo, Text, ModuleName, userId);

            return createdTrackers;

        }

        public async Task<int> CreateLeadAsync(LeadManualDTO manualLead, int userId)
        {
            var leadSource = new LeadSource
            {
                Date = DateTime.Now,
                LeadsSource = "Manual",
                LeadSourceProject = "Manual",
                Name = manualLead.Name,
                MobNo = manualLead.MobNo,
                EmailId = manualLead.EmailId,
                Requirement = manualLead.Requirement,
                Budget = manualLead.Budget,
                Purpose = manualLead.Purpose,
                Status = null,
                EnquiryType = string.Empty,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedBy = null,
                ModifiedBy = null,
            };
            await _leadSourceRepository.CreateAsync(leadSource).ConfigureAwait(false);

            var receiver1 = await _employeeRepository.GetEmployeeNameByIdAsync(2);
            var userName1 = await _employeeRepository.GetEmployeeNameByIdAsync(userId);
            var assignedToName = await _employeeRepository.GetEmployeeNameByIdAsync(manualLead.AssignedTo);

            string ModuleName = "Unassigned Leads";

            string Text1 = $"Hello {receiver1}, {userName1} has Generated a Lead and Assigned to {assignedToName}";
            await _notificationService.CreateNotificationForUser(2, Text1, ModuleName, userId);

            var receiver2 = await _employeeRepository.GetEmployeeNameByIdAsync(3);

            string Text2 = $"Hello {receiver2}, {userName1} has Generated a Lead and Assigned to {assignedToName}";
            await _notificationService.CreateNotificationForUser(3, Text2, ModuleName, userId);

            return leadSource.Id;
        }


    }
}

