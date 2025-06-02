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

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    public class Company
    {
        /// <summary>
        ///  AMC
        /// </summary>
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

    public class CompanyStatesServed
    {
        public int CompanyId { get; set; }
        public int StateId { get; set; }
    }
}
