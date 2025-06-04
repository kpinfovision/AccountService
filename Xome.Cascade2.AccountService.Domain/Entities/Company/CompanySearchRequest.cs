using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities.Pagination;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    public class CompanySearchRequest
    {
        public List<int> CompanyTypes { get; set; }
        public List<int> Services { get; set; }
        public List<int> StatesServed { get; set; }
        public bool Status { get; set; }
        public PagedRequest SortFilters { get; set; }
    }
}
