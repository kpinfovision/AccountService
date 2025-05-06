using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xome.Cascase2.AccountService.Domain.Entities;

namespace Xome.Cascase2.AccountService.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task AddUser(User User);
        Task UpdateUser(User User);
        Task DeleteUser(int id);
    }
}
