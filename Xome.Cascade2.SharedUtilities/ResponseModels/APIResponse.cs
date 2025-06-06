using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.SharedUtilities.ResponseModels.StatusCodes;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class APIResponse
    {
        public int Code { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Description { get; set; }

        public ResponseEnvelope ResponseEnvelope { get; set; }

       // public ExceptionInfo ExceptionDetails { get; set; }

        public object PayLoad { get; set; }

        public APIResponse(int statusCode, string description = null, object payLoad = null, ResponseEnvelope envelope = null)
        {
            Code = 0;
            StatusCode = (HttpStatusCode)statusCode;
            Description = description;
            ResponseEnvelope = envelope;
            PayLoad = payLoad;
        }

        public APIResponse(BusinessCode businessCode, int statusCode, string description = null, object payLoad = null, ResponseEnvelope envelope = null)
        {
            Code = businessCode.Code;
            StatusCode = (HttpStatusCode)statusCode;
            Description = description;
            ResponseEnvelope = envelope;
            PayLoad = payLoad;
        }
    }

    public class APIResponse<T> : APIResponse where T : Pagination
    {
        public Pagination Pagination { get; set; }

        public APIResponse(int statusCode, string description = null, object payLoad = null, ResponseEnvelope envelope = null, Pagination pagination = null)
            : base(statusCode, description, payLoad, envelope)
        {
            Pagination = pagination;
        }

        public APIResponse(BusinessCode businessCode, int statusCode, string description = null, object payLoad = null, ResponseEnvelope envelope = null, Pagination pagination = null)
            : base(businessCode, statusCode, description, payLoad, envelope)
        {
            Pagination = pagination;
        }
    }
}
