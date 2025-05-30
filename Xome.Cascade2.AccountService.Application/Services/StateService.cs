using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public class StateService
    {
        private readonly IUnitOfWork _unitOfWork;

        // , IStateService stateService
        public StateService(IUnitOfWork unitOfWork, CamundaService camundaService, ServiceBusPublisher publisher)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<States>> GetAllStates()
        {
            return await _unitOfWork.States.GetAllStates();
        }
    }
}
