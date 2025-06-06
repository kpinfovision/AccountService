using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Xome.Cascade2.SharedUtilities.ResponseModels.StatusCodes;
using Xome.Cascade2.SharedUtilities.Extensions;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public abstract class BaseAPIResponseMiddleware
    {
        private readonly RequestDelegate _next;

        private const string _contentType = "application/json";

        public BaseAPIResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public virtual async Task Invoke(HttpContext context)
        {
            if (SkipMiddleware(context))
            {
                await _next(context);
                return;
            }

            Stream originalBodyStream = context.Response.Body;
            using MemoryStream responseBody = new MemoryStream();
            context.Response.Body = responseBody;
            try
            {
                await _next(context);
                Tuple<ResponseEnvelope, string> envelope = PrepareResponseEnvelope(context);
                if (context.Response.StatusCode != 200)
                {
                    await HandleNotSuccessRequestAsync(context, envelope);
                }
                else
                {
                    await HandleSuccessRequestAsync(context, await FormatResponse(context.Response), envelope);
                }
            }
            //catch (GenericException exception)
            //{
            //    await HandleExceptionAsync(context, exception);
            //}
            //catch (ConstraintViolationException exception2)
            //{
            //    await HandleExceptionAsync(context, exception2);
            //}
            //catch (ValidationException exception3)
            //{
            //    await HandleExceptionAsync(context, exception3);
            //}
            //catch (RecordNotFoundException exception4)
            //{
            //    await HandleExceptionAsync(context, exception4);
            //}
            //catch (OperationTimeoutException exception5)
            //{
            //    await HandleExceptionAsync(context, exception5);
            //}
            //catch (DatabaseConcurrencyException exception6)
            //{
            //    await HandleExceptionAsync(context, exception6);
            //}
            catch (Exception exception7)
            {
                await HandleExceptionAsync(context, exception7);
            }
            finally
            {
                responseBody.Seek(0L, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string text = string.Empty;
            Guid guid = Guid.NewGuid();
            BusinessCode businessCode = BusinessCode.GenericError;
            HttpStatusCode statusCode;
            if (exception is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                businessCode = BusinessCode.AuthorizationException;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                text = exception?.GetBaseException()?.Message;
            }

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";
            string text2 = GetDescription(context.Response.StatusCode.ToString()) ?? text;
            APIResponse data = new APIResponse(businessCode, context.Response.StatusCode, text2)
            {
                //ExceptionDetails = new ExceptionInfo
                //{
                //    ReferenceId = guid,
                //    ExceptionData = ExceptionData.CreateExceptionData(exception)
                //}
            };
            LogError($"{guid}_{text2}", exception);
            context.Response.Body.SetLength(0L);
            return context.Response.WriteAsync(data.ToSerializeString());
        }

        private Task HandleExceptionAsync(HttpContext context, GenericException exception)
        {
            Guid guid = Guid.NewGuid();
            context.Response.StatusCode = 422;
            context.Response.ContentType = "application/json";
            APIResponse data = new APIResponse(exception.BusinessCode, context.Response.StatusCode, exception.EndUserMessage)
            {
                //ExceptionDetails = new ExceptionInfo
                //{
                //    ReferenceId = guid,
                //    ExceptionData = ExceptionData.CreateExceptionData(exception)
                //}
            };
            LogError($"{guid}_{exception.EndUserMessage}", exception);
            context.Response.Body.SetLength(0L);
            return context.Response.WriteAsync(data.ToSerializeString());
        }

        //private Task HandleExceptionAsync(HttpContext context, ConstraintViolationException exception)
        //{
        //    Guid guid = Guid.NewGuid();
        //    context.Response.StatusCode = 412;
        //    context.Response.ContentType = "application/json";
        //    APIResponse data = new APIResponse(exception.BusinessCode, context.Response.StatusCode, exception.EndUserMessage)
        //    {
        //        ExceptionDetails = new ExceptionInfo
        //        {
        //            ReferenceId = guid,
        //            ExceptionData = ExceptionData.CreateExceptionData(exception)
        //        }
        //    };
        //    LogError($"{guid}_{exception.EndUserMessage}_recordId_{exception.Id}_constraintId_{exception.ConstraintId}_entity_{exception.Entity}", exception);
        //    context.Response.Body.SetLength(0L);
        //    return context.Response.WriteAsync(data.ToSerializeString());
        //}

        //private Task HandleExceptionAsync(HttpContext context, DatabaseConcurrencyException exception)
        //{
        //    Guid guid = Guid.NewGuid();
        //    context.Response.StatusCode = 412;
        //    context.Response.ContentType = "application/json";
        //    APIResponse data = new APIResponse(exception.BusinessCode, context.Response.StatusCode, exception.EndUserMessage)
        //    {
        //        ExceptionDetails = new ExceptionInfo
        //        {
        //            ReferenceId = guid,
        //            ExceptionData = ExceptionData.CreateExceptionData(exception)
        //        }
        //    };
        //    LogError($"{guid}_{exception.EndUserMessage}_recordId_{exception.Id}_entity_{exception.Entity}", exception);
        //    context.Response.Body.SetLength(0L);
        //    return context.Response.WriteAsync(data.ToSerializeString());
        //}

        //private Task HandleExceptionAsync(HttpContext context, ValidationException exception)
        //{
        //    Guid guid = Guid.NewGuid();
        //    context.Response.StatusCode = 422;
        //    context.Response.ContentType = "application/json";
        //    ResponseEnvelope payLoad = new ResponseEnvelope();
        //    APIResponse data = new APIResponse(exception.BusinessCode, context.Response.StatusCode, exception.EndUserMessage, payLoad)
        //    {
        //        ExceptionDetails = new ExceptionInfo
        //        {
        //            ReferenceId = guid,
        //            ExceptionData = ExceptionData.CreateExceptionData(exception)
        //        }
        //    };
        //    LogError($"{guid}_{exception.EndUserMessage}", exception);
        //    context.Response.Body.SetLength(0L);
        //    return context.Response.WriteAsync(data.ToSerializeString());
        //}

        //private Task HandleExceptionAsync(HttpContext context, RecordNotFoundException exception)
        //{
        //    Guid guid = Guid.NewGuid();
        //    context.Response.StatusCode = 412;
        //    context.Response.ContentType = "application/json";
        //    APIResponse data = new APIResponse(exception.BusinessCode, context.Response.StatusCode, exception.EndUserMessage)
        //    {
        //        ExceptionDetails = new ExceptionInfo
        //        {
        //            ReferenceId = guid,
        //            ExceptionData = ExceptionData.CreateExceptionData(exception)
        //        }
        //    };
        //    LogError($"{guid}_{exception.EndUserMessage}_recordId_{exception.Id}_entity_{exception.Entity}", exception);
        //    context.Response.Body.SetLength(0L);
        //    return context.Response.WriteAsync(data.ToSerializeString());
        //}

        //private Task HandleExceptionAsync(HttpContext context, OperationTimeoutException exception)
        //{
        //    Guid guid = Guid.NewGuid();
        //    context.Response.StatusCode = 412;
        //    context.Response.ContentType = "application/json";
        //    APIResponse data = new APIResponse(exception.BusinessCode, context.Response.StatusCode, exception.EndUserMessage)
        //    {
        //        ExceptionDetails = new ExceptionInfo
        //        {
        //            ReferenceId = guid,
        //            ExceptionData = ExceptionData.CreateExceptionData(exception)
        //        }
        //    };
        //    LogError($"{guid}_{exception.EndUserMessage}_resource_{exception.Resource}", exception);
        //    context.Response.Body.SetLength(0L);
        //    return context.Response.WriteAsync(data.ToSerializeString());
        //}

        private Task HandleNotSuccessRequestAsync(HttpContext context, Tuple<ResponseEnvelope, string> envelope)
        {
            context.Response.ContentType = "application/json";
            string description = envelope.Item2 ?? "Your request cannot be processed. Please contact a support.";
            APIResponse data = new APIResponse(context.Response.StatusCode, description, null, envelope.Item1);
            context.Response.Body.SetLength(0L);
            return context.Response.WriteAsync(data.ToSerializeString());
        }

        private Task HandleSuccessRequestAsync(HttpContext context, object body, Tuple<ResponseEnvelope, string> envelope)
        {
            context.Response.ContentType = "application/json";
            string text = envelope.Item2 ?? "Success";
            dynamic val = JsonConvert.DeserializeObject<object>(((!body.ToString().IsValidJson()) ? JsonConvert.SerializeObject(body) : body.ToString()) ?? string.Empty);
            APIResponse data = ((!(context.Items["PaginationEnvelope"] is Pagination pagination)) ? new APIResponse(context.Response.StatusCode, text, val, envelope.Item1) : new APIResponse<Pagination>(context.Response.StatusCode, text, val, envelope.Item1, pagination));
            context.Response.Body.SetLength(0L);
            return context.Response.WriteAsync(data.ToSerializeString());
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0L, SeekOrigin.Begin);
            string result = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0L, SeekOrigin.Begin);
            return result;
        }

        private bool SkipMiddleware(HttpContext context)
        {
            List<string> source = new List<string>
        {
            "/swagger", "/api/FileStorage/Download", "/api/ClaimsExport/Export", "/api/ClaimsExport/ExportToCsv", "/api/CashCollection/CashCollectionReport", "/api/EditCheck/EditCheckExcelReport", "/api/MealCount/MealCountBySiteExcelReport", "/api/MenuItems/MenuItemDailySummaryExcelReport", "/api/MenuItems/MenuItemSummaryExcelReport", "/api/PatronParticipation/PartonDetailExcelReport",
            "/api/PatronParticipation/PartonSummaryExcelReport", "/api/PatronParticipation/PartonNonReport", "/api/Payments/PaymentDetailExcelReport", "/api/Payments/PaymentSummaryExcelReport", "/api/RevenueReport/RevenueExcelReport", "/api/Application/ApplicationCountExcel", "/api/Application/EligibilitySummaryExcel", "/api/Application/DCSummaryExcel", "/api/IncomeSurvey/EcoDisadvantagedReportExcel", "/api/IncomeSurvey/IncomeSurveyReportExcel",
            "/api/MealCount/MealCountByEligibilityExcelReport", "/api/EditCheck/EditCheckWorkSheetExcelReport", "/api/ActivityReport/ActivityExcelReport", "/api/ExcelDownloads", "/api/Deposit/ExportToExcel", "/api/DataQuery/DownloadAsync", "/api/Import/DownloadImportException"
        };
            if (!context.Request.Headers.Keys.Any((string x) => x.Trim().ToLower().Equals("skipresponsemiddleware")))
            {
                return source.Any((string s) => context.Request.Path.StartsWithSegments(s));
            }

            return true;
        }

        private string GetDescription(string code, int languageId = 1, int regionId = -10)
        {
            return GetMessageData(new List<string> { code }, languageId, regionId)?.FirstOrDefault()?.Description;
        }

        private List<HttpStatusMessage> GetMessageData(List<string> codes, int languageId = 1, int regionId = -10)
        {
            IEnumerable<HttpStatusMessage> enumerable = HttpStatusMessageCodes.statusMessages.Where((HttpStatusMessage x) => x.RegionId == regionId && x.LanguageId == languageId && codes.Contains(x.Code));
            if (enumerable == null)
            {
                return new List<HttpStatusMessage>();
            }

            return enumerable.ToList();
        }

        private void SetDescription<T>(IEnumerable<T> info, List<HttpStatusMessage> messages) where T : BaseMessage
        {
            if (info == null || !messages.Any())
            {
                return;
            }

            foreach (T item in info.Where((T x) => x.Code != BaseStatusCodes.Common.CustomMessage))
            {
                string description = messages.FirstOrDefault((HttpStatusMessage y) => y.Code == item.Code)?.Description;
                item.Description = SetArgumentsToDescription(description, item.Arguments);
            }
        }

        private string SetArgumentsToDescription(string description, object[] args)
        {
            if (args == null || !args.Any() || string.IsNullOrWhiteSpace(description))
            {
                return description;
            }

            try
            {
                description = string.Format(description, args);
            }
            catch (Exception)
            {
            }

            return description;
        }

        private Tuple<ResponseEnvelope, string> PrepareResponseEnvelope(HttpContext context)
        {
            List<string> list = new List<string> { context.Response.StatusCode.ToString() };
            ResponseEnvelope responseEnvelope = context.Items["ResponseEnvelope"] as ResponseEnvelope;
            if (responseEnvelope != null)
            {
                if (responseEnvelope.MessageInfoCollection != null)
                {
                    list.AddRange(responseEnvelope.MessageInfoCollection.Select((MessageInfo n) => n.Code));
                }

                if (responseEnvelope.NotificationCollection != null)
                {
                    list.AddRange(responseEnvelope.NotificationCollection.Select((NotificationInfo n) => n.Code));
                }

                if (responseEnvelope.ValidationCollection != null)
                {
                    list.AddRange(responseEnvelope.ValidationCollection.Select((ValidationInfo n) => n.Code));
                }
            }

            List<HttpStatusMessage> messageData = GetMessageData(list);
            if (responseEnvelope != null)
            {
                SetDescription(responseEnvelope.MessageInfoCollection, messageData);
                SetDescription(responseEnvelope.NotificationCollection, messageData);
                SetDescription(responseEnvelope.ValidationCollection, messageData);
            }

            string item = messageData?.FirstOrDefault((HttpStatusMessage x) => x.Code == context.Response.StatusCode.ToString())?.Description;
            return Tuple.Create(responseEnvelope, item);
        }

        protected abstract void LogError(string message, Exception exception);
    }
}
