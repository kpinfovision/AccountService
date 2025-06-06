using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.SharedUtilities.ResponseModels.StatusCodes;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class GenericException : BaseException
    {
        public GenericException(BusinessCode code, string message)
            : base(code, message)
        {
        }
    }
}
