using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public class CompanyTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        // ICompanyTypeService companyTypeService
        public CompanyTypeService(IUnitOfWork unitOfWork, CamundaService camundaService, ServiceBusPublisher publisher)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CompanyTypes>> GetAllCompanyTypes()
        {
            return await _unitOfWork.CompanyTypes.GetAllCompanyTypes();
        }
    }
}
