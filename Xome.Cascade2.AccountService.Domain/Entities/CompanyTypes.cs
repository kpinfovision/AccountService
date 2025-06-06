using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    [Table("ORG_TYPE")]
    public class CompanyTypes
    {
        [Key]
        [Column("ORG_TYPE_ID")]    
        public int CompanyTypeId { get; set; }

        [Column("NAME")]
        [MaxLength(50)]
        public string CompanyTypeName { get; set; }

        [Column("ACTIVE")]
        public bool Active { get; set; }
    }
}
