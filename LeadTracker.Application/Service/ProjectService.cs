using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectrepository;
        private readonly IMapper _mappingProfile;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly INotificationService _notificationService;

        public ProjectService(IMapper mappingProfile, IProjectRepository projectService, IEmployeeRepository employeeRepository, INotificationService notificationService)
        {
            _mappingProfile = mappingProfile;
            _projectrepository = projectService;
            _employeeRepository = employeeRepository;
            _notificationService = notificationService;
        }

        public async Task<string> WriteFiles(IFormFile file, string projectName)
        {
            string filename = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), $"Upload\\Project\\{projectName}");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var outputFile = Path.Combine($"Upload\\Project\\{projectName}\\" + file.FileName);
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


        public async Task CreateProject(ProjectDTO project, int userId)
        {
            var proj = new Project[1];
            proj[0] = new Project()
            {
                ProjectName = project.ProjectName,
                LocationId = project.LocationId,
                Address = project.Address,
                BuilderName = project.BuilderName,
                CompanyPercentage = project.CompanyPercentage,
                EmployeePercentage = project.EmployeePercentage,
                TDS = project.TDS,
                CreatedBy = userId,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy = userId,
            };
            if (project.Files != null)
            {
                var fileNames = new List<string>();

                foreach (var file in project.Files)
                {
                    var outputFile = await WriteFiles(file, project.ProjectName);
                    if (!string.IsNullOrEmpty(outputFile))
                    {
                        fileNames.Add(outputFile);
                        //emps[0].Document = outputFile;
                    }
                }
                proj[0].Document = string.Join(", ", fileNames);
            }

            var assignedToName = await _employeeRepository.GetEmployeeNameByIdAsync(userId);

            string ModuleName = "New Project";



            await _notificationService.NotificationForNewProjectAsync(ModuleName, userId, assignedToName);


            await _projectrepository.RegisterNewProjectAsync(proj).ConfigureAwait(false);
        }

        public async Task<Project> UpdateProjectAsync(int id, ProjectDTO project, int userId)
        {
            var existingProject = await _projectrepository.GetByIdAsync(id).ConfigureAwait(false);

            if (existingProject != null)
            {
                existingProject.ProjectName = project.ProjectName;
                existingProject.LocationId = project.LocationId;
                existingProject.Address = project.Address;
                existingProject.BuilderName = project.BuilderName;
                existingProject.CompanyPercentage = project.CompanyPercentage;
                existingProject.EmployeePercentage = project.EmployeePercentage;
                existingProject.TDS = project.TDS;
                existingProject.ModifiedDate = DateTime.Now;
                existingProject.ModifiedBy = userId;

                if (project.Files != null)
                {
                    //var fileNames = new List<string>();
                    var fileNames = existingProject.Document?.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<string>();


                    foreach (var file in project.Files)
                    {
                        //var employeeName = existingEmployee.Name;  
                        var outputFile = await WriteFiles(file, existingProject.ProjectName);
                        if (!string.IsNullOrEmpty(outputFile))
                        {
                            //existingEmployee.Document = outputFile;
                            fileNames.Add(outputFile);
                        }
                    }
                    existingProject.Document = string.Join(", ", fileNames);
                }
                await _projectrepository.UpdateAsync(existingProject).ConfigureAwait(false);
                return existingProject;
            }
            return null;

        }

        //public async Task CreateProject(ProjectDTO project)
        //{
        //    var proj = _mappingProfile.Map<Project>(project);
        //    await _projectrepository.CreateAsync(proj).ConfigureAwait(false);
        //}

        public async Task<NewProjectDTO> GetProjectByIdAsync(int id)
        {
            var project = await _projectrepository.GetByIdAsync(id);

            var projectDTO = _mappingProfile.Map<NewProjectDTO>(project);

            return projectDTO;
        }

        //public async Task<IEnumerable<ProjectDTO>> GetAllProjectAsync()
        //{
        //    var projects = await _projectrepository.GetAllAsync();
        //    var projectsDTO = _mappingProfile.Map<List<ProjectDTO>>(projects);
        //    return projectsDTO.ToList();
        //}

        public async Task<IEnumerable<NewProjectDTO>> GetAllProjectAsync()
        {
            var projects = await _projectrepository.GetAllAsync();

            var filteredProjects = projects.Where(p => p.IsActive && !p.IsDeleted).ToList();

            var projectsDTO = _mappingProfile.Map<List<NewProjectDTO>>(filteredProjects);

            return projectsDTO;
        }

        //public async Task UpdateProjectAsync(int id, ProjectDTO project)
        //{
        //    var existingProject = await _projectrepository.GetByIdAsync(id);
        //    _mappingProfile.Map(project, existingProject);
        //    await _projectrepository.UpdateAsync(existingProject);

        //    //var proj = _mappingProfile.Map<Project>(project);
        //    //await _projectrepository.UpdateAsync(proj);
        //}

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _projectrepository.GetByIdAsync(id);
            if (project != null)
            {
                await _projectrepository.DeleteAsync(id);
            }
        }
    }
}
