using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public abstract class APIResponseMiddlewareEx : BaseAPIResponseMiddleware
    {
        private readonly ILogger<APIResponseMiddlewareEx> _logger;

        public APIResponseMiddlewareEx(RequestDelegate next, ILogger<APIResponseMiddlewareEx> logger)
            : base(next)
        {
            _logger = logger;
        }

        protected override void LogError(string message, Exception exception)
        {
            _logger.LogError(exception, message);
        }
    }
}
