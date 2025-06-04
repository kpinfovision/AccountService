using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    public class CompanySaveRequest
    {
        public int CompanyId { get; set; }
        public bool Status { get; set; }

        [JsonIgnore]
        public int RemovedReason { get; set; } // not on priority

        public string CompanyName { get; set; }
        public int? TaxIDType { get; set; }

        public string? TaxID { get; set; }

        public string? Notes { get; set; }

        public string? LegalEntityName { get; set; }
        public bool IsOutsourced { get; set; }

        public int UserId { get; set; }

        public string DisplayName { get; set; } // need confirmation from PO
        public string Abbreviation { get; set; } // need confirmation from PO
        
        //public int?[] StateServed { get; set; }

        public AddressRequest Address { get; set; }

        public int AddressId { get; set; }
    }

    public class AddressRequest
    {
        public int AddressId { get; set; }        

        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? City { get; set; }

        public string State { get; set; } = string.Empty;

        public string? Zip { get; set; }        
        
        public bool Active { get; set; }        

        public DateTime CreatedOn { get; set; }        

        public int CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public int ModifiedBy { get; set; }


    }
}
