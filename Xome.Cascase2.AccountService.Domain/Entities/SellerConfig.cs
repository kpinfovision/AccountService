using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascase2.AccountService.Domain.Entities
{
    public class SellerConfig
    {
        public int Id { get; set; }
        public string ConfigName { get; set; }

        public bool Status { get; set; }
    }
}
