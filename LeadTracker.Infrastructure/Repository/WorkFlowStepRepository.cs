﻿using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LeadTracker.Infrastructure.Repository
{
    public class WorkFlowStepRepository : Repository<WorkFlowStep>, IWorkFlowStepRepository
    {
        private readonly LeadTrackerContext _context;
        public WorkFlowStepRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<WorkFlow> GetWorkFlowByOrgIdAsync(int orgId)
        {
            var workflow = _context.WorkFlows
                .Where(workflow => workflow.OrgId == orgId).ToList();

            return workflow.FirstOrDefault();

        }

        public async Task<IEnumerable<WorkFlowStep>> GetWorkFlowStepByOrgIdByIdAsync(int orgId)
        {
            return await _context.WorkFlowSteps
                .Where(workflowstep => workflowstep.OrgId == orgId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<WorkFlowStep> GetWorkFlowStepsByCurrentStepAsync(string currentStep, int orgId)
        {
            return await _context.WorkFlowSteps.FirstOrDefaultAsync(f=>f.StepName== currentStep && f.OrgId == orgId).ConfigureAwait(false);
        }




        public async Task<IEnumerable<NextStepDTO>> GetNextStepsByCurrentStepAsync(string currentStep, int currentStepWFId, int orgId)
        {
            var nextSteps = await _context.WorkFlowDetails
                .Include(f => f.WorkFlowPreviousStep)
                .Include(f => f.WorkFlowCurrentStep)
                .Include(f => f.WorkFlowNextStep)
                .Where(wfs => wfs.OrgId == orgId && wfs.WorkFlowCurrentStep.StepName == currentStep && wfs.WorkFlowId == currentStepWFId)
                .Select(wfs => wfs.WorkFlowNextStep)
                .Distinct()
                .Select(nextStep => new NextStepDTO { WorkFlowId = currentStepWFId, NextStep = nextStep.StepName, WorkFlowStepId = nextStep.Id})
                .ToListAsync()
                .ConfigureAwait(false);

            return nextSteps;
        }


        public async Task<string> GetWorkFlowStepNameByIdAsync(int workFlowStepId)
        {
            var workflowStep = await _context.WorkFlowSteps.FindAsync(workFlowStepId);
            return workflowStep?.StepName;
        }

        public async Task<string?> GetWorkFlowStepNameById(int StepId)
        {
            return await _context.WorkFlowSteps
                .Where(w => w.Id == StepId)
                .Select(w => w.StepName)
                .FirstOrDefaultAsync();
        }


    }
}
