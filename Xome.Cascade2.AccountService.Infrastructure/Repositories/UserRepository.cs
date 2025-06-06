﻿using Microsoft.EntityFrameworkCore;
using Xome.Cascade2.AccountService.Domain.Entities;
using Xome.Cascade2.AccountService.Domain.Interfaces;
using Xome.Cascade2.AccountService.Infrastructure.Data;

namespace Xome.Cascade2.AccountService.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) { 
            _context = context;
        }

        public async Task AddUser(User User)
        {
            await _context.Users.AddAsync(User);
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null) {
                _context.Users.Remove(user);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToArrayAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUser(User User)
        {
            _context.Users.Update(User);
        }

        public async Task<List<ManualTask>> GetAllCamundaTasks()
        {
            return _context.ManualTasks.ToList();
        }

        public async Task<List<TaskFields>> GetAllCamundaTaskFields()
        {
            return _context.TaskFields.ToList();
        }

        public async Task<List<UserTaskFieldMapping>> GetUserTaskFieldMappings()
        {
            return _context.UserTaskFieldMappings.ToList();
        }
    }
}
