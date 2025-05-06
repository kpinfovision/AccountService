using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xome.Cascase2.AccountService.Application.Services;
using Xome.Cascase2.AccountService.Domain.Interfaces;
using Xome.Cascase2.AccountService.Domain.Entities;
using Microsoft.Extensions.Options;

namespace Xome.Cascase2.AccountServiceService.UnitTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IUserRepository> _mockUserRepository;
        private UserService _userService;

        [SetUp]
        public void SetUp()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockUnitOfWork.Setup(u => u.Users).Returns(_mockUserRepository.Object);
            _userService = new UserService(_mockUnitOfWork.Object);
        }

        [Test]
        public async Task AddUser_Should_Call_AddUser_And_SaveChanges()
        {
            var user = new User { Id = 1, Email = "test@example.com" };

            await _userService.AddUser(user);

            _mockUserRepository.Verify(r => r.AddUser(user), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteUser_Should_Call_DeleteUser_And_SaveChanges()
        {
            int userId = 1;

            await _userService.DeleteUser(userId);

            _mockUserRepository.Verify(r => r.DeleteUser(userId), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task GetAllUsers_Should_Return_All_Users()
        {
            var expectedUsers = new List<User> { new User { Id = 1 }, new User { Id = 2 } };
            _mockUserRepository.Setup(r => r.GetAllUsers()).ReturnsAsync(expectedUsers);

            var result = await _userService.GetAllUsers();

            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetUserById_Should_Return_Correct_User()
        {
            var user = new User { Id = 1 };
            _mockUserRepository.Setup(r => r.GetUserById(1)).ReturnsAsync(user);

            var result = await _userService.GetUserById(1);

            Assert.AreEqual(user, result);
        }

        [Test]
        public async Task UpdateUser_Should_Call_UpdateUser_And_SaveChanges()
        {
            var user = new User { Id = 1 };

            await _userService.UpdateUser(user);

            _mockUserRepository.Verify(r => r.UpdateUser(user), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        //[Test]
        //public async Task GetUserDetails_Should_Return_User_Details()
        //{
        //    var users = new List<User>
        //    {
        //        new User { Id = 1, Email = "john.doe@example.com", FirstName = "John", LastName = "Doe", Role = "Admin" }
        //    };

        //    var tasks = new List<TaskEntity>
        //    {
        //        new TaskEntity { TaskId = 1, TaskName = "Review Documents" }
        //    };

        //    var mappings = new List<TaskFieldMapping>
        //    {
        //        new TaskFieldMapping { UserId = 1, TaskId = 1, AccessTaskFields = "Field1" }
        //    };

        //    _mockUserRepository.Setup(r => r.GetAllUsers()).ReturnsAsync(users);
        //    _mockUserRepository.Setup(r => r.GetAllCamundaTasks()).ReturnsAsync(tasks);
        //    _mockUserRepository.Setup(r => r.GetUserTaskFieldMappings()).ReturnsAsync(mappings);

        //    var result = await _userService.GetUserDetails("john.doe@example.com");

        //    Assert.NotNull(result);
        //    dynamic userDetails = result;
        //    Assert.AreEqual("John", userDetails.firstName);
        //    Assert.AreEqual("Doe", userDetails.lastName);
        //    Assert.AreEqual("john.doe@example.com", userDetails.username);
        //    Assert.AreEqual("Admin", userDetails.role);
        //}
    }
}
