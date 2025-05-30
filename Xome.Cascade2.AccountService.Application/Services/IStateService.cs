using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.Application.Services
{
    public interface IStateService
    {
        Task<IEnumerable<States>> GetAllStates();
    }
}
