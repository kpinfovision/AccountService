﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public class ValuationTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ValuationTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<ValuationType>> GetAllValuationTypesAsync()
        {
            var valuationTypes = await _unitOfWork.valuationTypes.GetAllValuationTypesAsync();
            return valuationTypes;
        }   
    }
}
