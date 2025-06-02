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
    public class Company
    {
        public int CompanyId { get; set; }
        public int CompanyType { get; set; }
        public int Status { get; set; }
        public int RemovedReason { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string PrimaryPhone { get; set; }
        public string Ext { get; set; }
        public int TaxIDType { get; set; }
        public int State { get; set; }
        public int[] StateServed { get; set; }
        public string Fax { get; set; }
        public string TaxID { get; set; }
        public string Zip { get; set; }
        public string Notes { get; set; }
        public string LegalEntityName { get; set; }
        public string DisplayName { get; set; }
        public string Abbreviation { get; set; }
    }
    //[Table("ASSET_MANAGEMENT")]
    //public class Company
    //{
    //    [Key]
    //    [Column("ASSET_MANAGEMENT_ID")]
    //    public int CompanyId { get; set; }

    //    [Column("NAME")]
    //    [Required]
    //    [MaxLength(30)]
    //    public string CompanyType { get; set; }

    //    [Column("STATUS")]
    //    public int Status { get; set; }

    //    [Column("ADDRESS")]
    //    [MaxLength(500)]
    //    public string? Address { get; set; }

    //    [Column("CREATED_ON")]
    //    public DateTime CreatedOn { get; set; }

    //    [Column("CREATED_BY")]
    //    public int CreatedBy { get; set; }

    //    [Column("MODIFIED_DATE")]
    //    public DateTime ModifiedDate { get; set; }

    //    [Column("MODIFIED_ON")]
    //    public int ModifiedBy { get; set; }

    //    [Column("ACTIVE")]
    //    public bool IsActive { get; set; }

    //    [Column("TAXTYPEID")]
    //    public int? TaxTypeId { get; set; }

    //    [Column("TAXID")]
    //    [MaxLength(100)]
    //    public string? TaxId { get; set; }

    //    [Column("NOTES")]
    //    [MaxLength(500)]
    //    public string? Notes { get; set; }

    //    [Column("LEGAL_ENTITY_NAME")]
    //    [MaxLength(100)]
    //    public string? LegalEntityName { get; set; }

    //    [Column("OUTSOURCE")]
    //    public bool? IsOutsourced { get; set; }

    //    [JsonIgnore]
    //    [Column("ADDRESS_ID")]
    //    public int? AddressId { get; set; }
    //}

    public class CompanyStatesServed
    {
        public int CompanyId { get; set; }
        public int StateId { get; set; }
    }
}
