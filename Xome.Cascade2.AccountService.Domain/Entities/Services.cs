using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    [Table("SERVICES")]
    public class Services
    {
        [Key]
        [Column("SERVICES_ID")]
        public int ServicesId {get; set;}
        [Column("SERVICE_NAME")]
        [MaxLength(50)]
        public string ServiceName {get; set;}
    }
}
