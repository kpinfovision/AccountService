using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.SharedUtilities.ResponseModels.StatusCodes;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class BaseException : Exception
    {
        public BusinessCode BusinessCode { get; protected set; }

        public string EndUserMessage { get; protected set; }

        public string Id { get; protected set; }

        public string ConstraintId { get; protected set; }

        public string Entity { get; protected set; }

        public string Resource { get; protected set; }

        public IEnumerable<ValidationInfo> Validations { get; protected set; } = new List<ValidationInfo>();


        public BaseException(BusinessCode code, string endUserMessage)
        {
            BusinessCode = code;
            EndUserMessage = endUserMessage;
        }
    }
}
