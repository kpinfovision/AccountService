﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public class LoadValuationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoadValuationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LoadValuation> GetXVMAsync()
        {
            var loadValuation = await _unitOfWork.LoadValuations.GetXVMAsync();
            return loadValuation;
        }   
    }
}
