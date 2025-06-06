using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class BaseEntity
    {
        public virtual string Id { get; set; }

        public virtual string Type { get; set; }

        public virtual string SchemaVersion { get; set; } = "1.0.1";


        public virtual int CreatedBy { get; set; }

        public virtual DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
