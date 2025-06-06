using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public class FeatureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _connectionString;

        public FeatureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Feature>> GetFeatures()
        {
            // return await _unitOfWork.Features.GetAllFeatures();
            return await _unitOfWork.Repository<Feature>().ListAllAsync();
        }

        public async Task<Feature> GetFeatureByUserId(int userId)
        {
            return await _unitOfWork.Repository<Feature>().GetByIdAsync(userId);
        }
    }
}
