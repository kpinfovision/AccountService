﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.AccountService.Domain.Entities
{
    public class TokenResponse
    {
        public string access_token {  get; set; }
        public string token_type { get; set; }
    }
}
