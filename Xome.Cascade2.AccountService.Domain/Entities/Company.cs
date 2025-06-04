using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    [Table("ASSET_MANAGEMENT")]
    public class Company
    {
        [Column("ASSET_MANAGEMENT_ID")]
        public int CompanyId { get; set; }

        [Column("ACTIVE")]
        public bool Status { get; set; }
              
        [Column("NAME")]
        [Required]
        [MaxLength(30)]
        public string CompanyName { get; set; }
        [Column("TAX_TYPE_ID")]
        public int? TaxIDType { get; set; }

        [Column("TAX_ID")]
        [MaxLength(100)]
        public string? TaxID { get; set; }
        [Column("NOTES")]
        [MaxLength(500)]
        public string? Notes { get; set; }

        [Column("LEGAL_ENTITY_NAME")]
        [MaxLength(100)]
        public string? LegalEntityName { get; set; }

        [Column("OUTSOURCE")]
        [Required]
        public bool IsOutsourced { get; set; }

        [Column("CREATED_ON")]
        public DateTime CreatedOn { get; set; }

        [Column("CREATED_BY")]
        public int CreatedBy { get; set; }

        [Column("MODIFIED_ON")]
        public DateTime? ModifiedDate { get; set; }

        [Column("MODIFIED_BY")]
        public int? ModifiedBy { get; set; }
      //  public string DisplayName { get; set; } // need confirmation from PO
        public string Abbreviation { get; set; } // need confirmation from PO
        //public int[] StateServed { get; set; }

        
        /// below are attributes of address
       // public string Address { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string Zip { get; set; }
        // public string Fax { get; set; }
        //// public string PrimaryPhone { get; set; }
        // public string Ext { get; set; }

        [JsonIgnore]
        [Column("ADDRESS_ID")]
        public int AddressId { get; set; }

        public Address Address { get; set; }
    }

    [Table("ORG_STATE")]
    public class CompanyStatesServed
    {
        [Key]
        [Column("ORG_STATES_ID")]
        public int CompanyStatesId { get; set; }

        [Column("ORG_TYPE_SERVICE_ID")]
        public int? CompanyId { get; set; }

        [Column("STATE_ID")]
        public int? StateId { get; set; }
    }
}
