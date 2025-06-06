using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    [Table("TAX_TYPE")]
    public class TaxIDTypes
    {
        [Key]
        [Column("TAX_TYPE_ID")]
        public int TaxTypeId { get; set; }

        [Required]
        [Column("TAX_TYPE")]
        [StringLength(100)]
        public string TaxTypeName { get; set; } = string.Empty;

        [Required]
        [Column("ACTIVE")]
        public bool Active { get; set; }

        [Required]
        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }

        [Required]
        [Column("CREATED_ON")]
        public DateTime CreatedOn { get; set; }

        [Column("MODIFIED_BY")]
        public int? ModifiedBy { get; set; }

        [Column("MODIFIED_ON")]
        public DateTime? ModifiedOn { get; set; }
    }
}
