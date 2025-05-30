using Xome.Cascade2.AccountService.Domain.Entities;

namespace Xome.Cascade2.AccountService.Domain.Interfaces
{
    public interface IStateRepository
    {
        Task<IEnumerable<States>> GetAllStates();
    }
}
