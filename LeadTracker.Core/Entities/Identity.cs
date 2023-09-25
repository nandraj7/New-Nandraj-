using System.ComponentModel.DataAnnotations;

namespace LeadTracker.Core.Entities
{
    public abstract class Identity
    {
        [Key]
        public int Id { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
