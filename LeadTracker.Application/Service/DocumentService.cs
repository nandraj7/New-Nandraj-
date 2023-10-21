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

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentrepository= documentRepository;
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

                var outputFile = "Upload\\Files\\" + filename;
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
    }
}
