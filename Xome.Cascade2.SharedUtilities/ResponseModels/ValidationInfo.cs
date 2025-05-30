using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class ValidationInfo : BaseMessage
    {
        public string Field { get; set; }

        public ValidationInfo(string description, string code, string field = null, object[] args = null)
            : base(description, code, args)
        {
            Field = field;
        }

        public ValidationInfo(string code, string field = null, object[] args = null)
            : base(string.Empty, code, args)
        {
            Field = field;
        }
    }
}
