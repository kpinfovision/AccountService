using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities.Pagination;
using Xome.Cascade2.SharedUtilities.ResponseModels;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public abstract class BaseService<T> where T : BaseService<T>
    {
        internal MappingProfile MappingProfile;

        protected BaseService()
        {
            MappingProfile = new MappingProfile();
        }

        public ResponseEnvelope ResponseEnvelope { get; set; } = new ResponseEnvelope();
        public Pagination PaginationEnvelope { get; set; }

        public ResponseEnvelope GetResponseEnvelope()
        {
            return ResponseEnvelope;
        }

    }
}
