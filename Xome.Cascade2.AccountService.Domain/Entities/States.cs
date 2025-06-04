using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    [Table("STATES")]
    public class States
    {
        [Key]
        [Column("STATE_ID")] 
        public int StateId { get; set; }

        [Column("STATE_NAME")]
        [MaxLength(100)]
        public string StateName { get; set; }

        [Column("CODE")]
        [MaxLength(2)]
        public string StateCode { get; set; }
    }
}
