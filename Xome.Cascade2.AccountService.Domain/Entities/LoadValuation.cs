using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    public class LoadValuation
    {
        public int Id { get; set; }
        public string AssetId { get; set; }  // : 29490
        public string ValuationEffectiveDate { get; set; } // : 06/05/2024
        public string ValuationType { get; set; } // : Automated Valuation Model
        public string AsIsValue { get; set; } // : $880580
    }
}
