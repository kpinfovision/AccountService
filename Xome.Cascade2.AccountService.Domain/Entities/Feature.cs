using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    [Table("FEATURE")]
    public class Feature
    {
        [Column("FEATURE_ID")]
        public int FeatureId { get; set; }

        [Column("FEATURE_NAME")]
        [Required]
        [MaxLength(50)]
        public string FeatureName { get; set; } = null!;

        [Column("ACTIVE")]
        public bool IsActive { get; set; }

        [Column("CREATED_ON")]
        public DateTime CreatedOn { get; set; }

        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }

        [Column("MODIFIED_ON")]
        public DateTime? ModifiedOn { get; set; }

        [Column("MODIFIED_BY")]
        public int? ModifiedBy { get; set; }
    }
}