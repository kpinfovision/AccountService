using Xome.Cascade2.SharedUtilities.ResponseModels;

namespace Xome.Cascade2.AccountService.WebApi.Middlewares
{
    public class ResponseMiddleware : APIResponseMiddlewareEx
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseMiddleware"/> class.
        /// </summary>
        /// <param name="next">next.</param>
        /// <param name="httpStatusMessageFactory">httpStatusMessageFactory.</param>
        /// <param name="logger">logger.</param>
        public ResponseMiddleware(RequestDelegate next, ILogger<ResponseMiddleware> logger)
            : base(next, logger)
        {
        }
    }
}
