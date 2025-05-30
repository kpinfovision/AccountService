using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class NotificationInfo : BaseMessage
    {
        public NotificationType NotificationType { get; set; }

        public NotificationInfo(string description, string code, NotificationType notificationType)
            : base(description, code)
        {
            NotificationType = notificationType;
        }

        public NotificationInfo(string code, NotificationType notificationType)
            : base(string.Empty, code)
        {
            NotificationType = notificationType;
        }
    }
}
