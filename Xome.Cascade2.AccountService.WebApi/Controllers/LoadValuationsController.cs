﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xome.Cascade2.AccountService.Application.Services;
using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadValuationsController : ControllerBase
    {
        public readonly LoadValuationService _loadValuationService;
        private static long _apiHitCount = 0;

        public LoadValuationsController(LoadValuationService loadValuationService)
        {
            _apiHitCount++;
            _loadValuationService = loadValuationService;
        }

        [HttpGet]
        public async Task<dynamic> GetAllLoadValuations()
        {
            if(_apiHitCount%3 == 0)
            {
                return await _loadValuationService.GetXVMAsync();
            }
            else
            {
                throw new Exception();
            }
        }   
    }
}
