using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.SharedUtilities;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class MessageInfo : BaseMessage
    {
        public MessageType MessageType { get; set; }

        public MessageInfo(string description, string code, MessageType messageType = MessageType.SUCCESS)
            : base(description, code)
        {
            MessageType = messageType;
        }

        public MessageInfo(string code, MessageType messageType = MessageType.SUCCESS)
            : base(string.Empty, code)
        {
            MessageType = messageType;
        }
    }
}
