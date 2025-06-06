﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xome.Cascade2.AccountService.Application.Services;
using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerConfigController : ControllerBase
    {
        public readonly SellerConfigService _sellerConfigService;

        public SellerConfigController(SellerConfigService sellerConfigService)
        {
            _sellerConfigService = sellerConfigService;
        }

        [HttpGet]
        public async Task<SellerConfig> GetAllSellerConfigs()
        {
            return await _sellerConfigService.GetSellerConfigAsync();
        }

        [HttpPut("Toggle")]
        public async Task<SellerConfig> ToggleSellerConfig()
        {
            return await _sellerConfigService.ToggleSellerConfig();
        }
    }
}
