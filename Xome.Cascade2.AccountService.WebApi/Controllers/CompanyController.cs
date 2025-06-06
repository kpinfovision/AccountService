using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xome.Cascade2.AccountService.Application.Services;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.SharedUtilities.ResponseModels;
using Xome.Cascade2.SharedUtilities.Extensions;
using System.Net;

namespace Xome.Cascade2.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public readonly CompanyService _companyService;
        private readonly IEntityRepository<Company> _entityRepository;
        public CompanyController(CompanyService companyService, IEntityRepository<Company> entityRepository)
        {
            _companyService = companyService;
            _entityRepository = entityRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(List<CompanySaveRequest> companyRequest) // List<CompanySaveRequest> companyRequest
        {
            try
            {
                List<CompanySaveRequest> companies = new List<CompanySaveRequest>();
                var result = await _companyService.BulkInsertCompanyAsync(companyRequest, false);

                if (result.Count != 0)
                {
                    var respObj = new ResponseEnvelope()
                    {
                        MessageInfoCollection = new List<MessageInfo>
                        { new MessageInfo("Asset Management Company successfully created", BaseStatusCodes.Common.CustomMessage, MessageType.SUCCESS) }
                    };
                    HttpContext.Items[APIConstants.RESPONSE_ENVELOPE] = respObj;
                    return StatusCode((int)HttpStatusCode.OK, result);
                }
                else
                {
                    HttpContext.Items[APIConstants.RESPONSE_ENVELOPE] = this._companyService.GetResponseEnvelope();
                    return StatusCode((int)HttpStatusCode.UnprocessableContent, new List<CompanySaveResponse>());
                }
            }
            catch (Exception ex) {

                var respObj = new ResponseEnvelope()
                {
                    MessageInfoCollection = new List<MessageInfo>
                        { new MessageInfo("Asset Management Company save failed See Validations for more details!", BaseStatusCodes.Common.CustomMessage, MessageType.ERROR) },
                    ValidationCollection = new List<ValidationInfo> { new ValidationInfo($"Error during bulk insert: {ex.Message}", BaseStatusCodes.Common.InternalServerError, field: null) }
                };
                HttpContext.Items[APIConstants.RESPONSE_ENVELOPE] = respObj;
                return StatusCode((int)HttpStatusCode.UnprocessableContent, new List<CompanySaveResponse>());
            }           
        }

        //[HttpPut]
        //public async Task UpdateCompany(Company company)
        //{
        //    await _companyService.UpdateCompany(company);
        //}

        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> SearchAssetManagementCompany(CompanySearchRequest companySearchRequest)
        {
            if (companySearchRequest.SortFilters.PageNumber != 0 && companySearchRequest.SortFilters.PageSize != 0)
            {
                var result = await _companyService.GetFilteredCompanies(companySearchRequest);
                if (this._companyService.GetPaginationEnvelope() != null)
                {
                    this.HttpContext.Items[APIConstants.RESPONSE_PAGINATION] = this._companyService.GetPaginationEnvelope();
                }
                return StatusCode((int)HttpStatusCode.OK, result);
            }
            else
            {
                var respObj = new ResponseEnvelope()
                {
                    MessageInfoCollection = new List<MessageInfo>
                        { new MessageInfo("Pagination info is needed.", BaseStatusCodes.Common.CustomMessage, MessageType.ERROR) }
                };

                HttpContext.Items[APIConstants.RESPONSE_ENVELOPE] = respObj;
                return StatusCode((int)HttpStatusCode.UnprocessableContent, respObj);
            }

        }

        [HttpGet]
        [Route("View")]
        public async Task<CompanySearchResponse> ViewAssetManagementCompanyProfile(int companyId)
        {
            return await _companyService.GetCompanyByCompanyId(companyId);
        }
    }
}
