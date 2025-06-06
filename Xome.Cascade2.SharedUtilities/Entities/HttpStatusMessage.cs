using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class HttpStatusMessage : BaseEntity
    {
        public override string Id => Type + "_" + HttpStatusMessageId;

        public override string Type => "HttpStatusMessage";

        public string HttpStatusMessageId { get; set; }

        public int LanguageId { get; set; }

        public int RegionId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
    }
}
