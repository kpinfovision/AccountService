using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public class StateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CamundaService _camundaService;
        private readonly string _connectionString;
        private readonly ServiceBusPublisher _publisher;

        // , IStateService stateService
        public StateService(IUnitOfWork unitOfWork, CamundaService camundaService, ServiceBusPublisher publisher)
        {
            _unitOfWork = unitOfWork;
            _camundaService = camundaService;
            _publisher = publisher;
        }

        public async Task<IEnumerable<States>> GetAllStates()
        {
            return await _unitOfWork.States.GetAllStates();
        }
    }
}
