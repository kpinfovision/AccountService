using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    [Table("ADDRESS")]
    public class Address
    {
        [Key]
        [Column("ADDRESS_ID")]
        public int AddressId { get; set; }

        [Column("ADDRESS_1")]
        [StringLength(50)]
        public string? Address1 { get; set; }

        [Column("ADDRESS_2")]
        [StringLength(50)]
        public string? Address2 { get; set; }

        [Column("CITY")]
        [StringLength(50)]
        public string? City { get; set; }

        [Column("STATE")]
        [StringLength(2)]
        public string? State { get; set; }

        [Column("ZIP")]
        [StringLength(10)]
        public string? Zip { get; set; }

        [Column("LATITUDE")]
        public decimal? Latitude { get; set; }

        [Column("LONGITUDE")]
        public decimal? Longitude { get; set; }

        [Column("ACTIVE")]
        public bool? Active { get; set; }

        [Column("CREATED_ON")]
        public DateTime CreatedOn { get; set; }

        [Column("CREATED_BY")]
        public int? CreatedBy { get; set; }

        [Column("MODIFIED_ON")]
        public DateTime? ModifiedOn { get; set; }

        [Column("MODIFIED_BY")]
        public int? ModifiedBy { get; set; }

        [Column("PHONE")]
        public int? Phone { get; set; }

        [Column("EXT")]
        public int? Ext { get; set; }
    }
}
