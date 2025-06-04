using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities.Pagination;
using Xome.Cascade2.SharedUtilities.ResponseModels;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    public class CompanySearchResponse
    {
        public string CompanyName { get; set; }
        public string Abbreviation { get; set; }
        public string LegalEntityName { get; set; }
        public string DisplayName { get; set; }
        public bool Active { get; set; }
        public string Status { get; set; }
        public string TaxId {  get; set; }
        public string TaxIdType { get; set; }
        public int TaxIdTypeId { get; set; }
        public AddressResponse Address {  get; set; }
    }

    public class AddressResponse
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateCd { get; set; }
        public string Zip { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Ext { get; set; }

    }
}
