using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class ResponseEnvelope
    {
        public IEnumerable<MessageInfo> MessageInfoCollection { get; set; }

        public IEnumerable<ValidationInfo> ValidationCollection { get; set; }

        public IEnumerable<NotificationInfo> NotificationCollection { get; set; }
    }
}
