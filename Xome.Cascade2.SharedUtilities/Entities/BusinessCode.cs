using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.SharedUtilities.ResponseModels.StatusCodes
{
    public class BusinessCode
    {
        public static BusinessCode Ok = new BusinessCode(0, "Ok");

        public static BusinessCode GenericError = new BusinessCode(101, "GenericError");

        public static BusinessCode QueryTimeout = new BusinessCode(102, "QueryTimeout");

        public static BusinessCode ApiTimeout = new BusinessCode(103, "ApiTimeout");

        public static BusinessCode RecordNotFound = new BusinessCode(104, "RecordNotFound");

        public static BusinessCode ValidationErrors = new BusinessCode(105, "ValidationErrors");

        public static BusinessCode ConstraintViolation = new BusinessCode(106, "ConstraintViolation");

        public static BusinessCode DatabaseConcurrencyException = new BusinessCode(107, "DatabaseConcurrencyException");

        public static BusinessCode AuthenticationException = new BusinessCode(108, "AuthenticationException");

        public static BusinessCode AuthorizationException = new BusinessCode(109, "AuthorizationException");

        public int Code { get; }

        public string Name { get; }

        public BusinessCode(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
