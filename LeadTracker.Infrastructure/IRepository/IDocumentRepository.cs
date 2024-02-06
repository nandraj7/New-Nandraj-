using LeadTracker.API;
using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Task CreateDocument(Document document);
        Task CreateTracker(Tracker tracker, StatusDTO status);
        Task CreateAllAsync(List<Document> entities);

    }
}
