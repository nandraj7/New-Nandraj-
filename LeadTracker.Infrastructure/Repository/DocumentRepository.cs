using LeadTracker.API;
using LeadTracker.Infrastructure.IRepository;
using Document = LeadTracker.API.Document;

namespace LeadTracker.Infrastructure.Repository
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {

        public DocumentRepository(LeadTrackerContext context) : base(context)
        {
        }
        public async Task CreateAllAsync(List<Document> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsActive = true;
                entity.CreatedDate = DateTime.UtcNow;
                entity.ModifiedDate = DateTime.UtcNow;
                entity.IsDeleted = false;


                await (_context as LeadTrackerContext).Documents.AddAsync(entity).ConfigureAwait(false);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
