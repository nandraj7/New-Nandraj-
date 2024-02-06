﻿using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpPost]
        public async Task<ActionResult> SaveProject([FromForm] ProjectDTO project)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);

            await _projectService.CreateProject(project, userId).ConfigureAwait(false);

            return Ok(project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject([FromForm] ProjectDTO project, int id)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);

            var updatedProject = await _projectService.UpdateProjectAsync(id, project, userId).ConfigureAwait(false);

            return Ok(updatedProject);
        }
        //[HttpPost]
        //public async Task<ActionResult> SaveProject(ProjectDTO project)
        //{
        //    await _projectService.CreateProject(project).ConfigureAwait(false);

        //    return Ok(project);
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<NewProjectDTO>> GetProject(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id).ConfigureAwait(false);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewProjectDTO>>> GetAllProject()
        {
            var project = await _projectService.GetAllProjectAsync().ConfigureAwait(false);
            return Ok(project);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProject(int id, ProjectDTO project)
        //{
        //    if (id != project.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await _projectService.UpdateProjectAsync(id, project).ConfigureAwait(false);
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProjectAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
