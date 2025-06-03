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
        [Column("USER_ID")]
        public int UserId { get; set; }

        [Key]
        [Column("ADDRESS_TYPE_ID")]
        public int AddressTypeId { get; set; }

        [Column("ADDRESS_1")]
        [MaxLength(50)]
        public string? AddressLine1 { get; set; }

        [Column("ADDRESS_2")]
        [MaxLength(50)]
        public string? AddressLine2 { get; set; }

        [Column("CITY")]
        [MaxLength(50)]
        public string? City { get; set; }

        [Column("STATE")]
        [MaxLength(2)]
        public string State { get; set; } = string.Empty;

        [Column("ZIP")]
        [MaxLength(10)]
        public string? Zip { get; set; }

        [Column("LATITUDE")]
        public decimal? Latitude { get; set; }

        [Column("LONGITUDE")]
        public decimal? Longitude { get; set; }

        [Column("IS_PRIMARY")]
        public bool IsPrimary { get; set; }

        [Column("ZIP5")]
        [MaxLength(5)]
        public string? Zip5 { get; set; }

        [Column("SERVICE_STATE")]
        [MaxLength(2)]
        public string ServiceState { get; set; } = string.Empty;

        [Column("FUNDING_STATE")]
        [MaxLength(2)]
        public string FundingState { get; set; } = string.Empty;        

        [Column("ACTIVE")]
        public bool IsActive { get; set; }

        [Column("CREATED_ON")]
        public DateTime CreatedOn { get; set; }

        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }

        [Column("MODIFIED_ON")]
        public DateTime ModifiedOn { get; set; }

        [Column("MODIFIED_BY")]
        public int ModifiedBy { get; set; }

        [Column("FAX")]
        [MaxLength(100)]
        public string? Fax { get; set; }

        [Column("PRIMARY_PHONE")]
        [MaxLength(100)]
        public string? PrimaryPhone { get; set; }

        [Column("EXT")]
        [MaxLength(10)]
        public string? Extension { get; set; }
    }
}
