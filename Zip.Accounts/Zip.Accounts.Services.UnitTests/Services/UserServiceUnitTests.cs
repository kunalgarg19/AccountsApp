using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zip.Accounts.Core.Dtos;
using Zip.Accounts.Core.Entities;
using Zip.Accounts.Core.Repositories;
using Zip.Accounts.Core.Services;
using Zip.Accounts.Services.Implementations;

namespace Zip.Accounts.Services.UnitTests.Services
{
    [TestClass]
    public class UserServiceUnitTests
    {
        private static Mock<IRepository<User>> _userRepositoryMock;
        private static Mock<IMapper> _mapperMock;
        private UserService _userService;
               

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            _userRepositoryMock = new Mock<IRepository<User>>();
            _mapperMock = new Mock<IMapper>();
        }        

        [TestMethod]
        public async Task GetUser_ValidEmail_ReturnsUser()
        {
            _mapperMock.Setup(m => m.Map<UserDto>(It.IsAny<User>())).Returns(new UserDto() { Email="unit@test.email.com"});
            _userRepositoryMock.SetReturnsDefault(new User());
            _userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object);
            
            
            var test = await _userService.GetUser("test@email.com");
            Assert.AreEqual(test.Result.Email, "unit@test.email.com");
        }

        [TestMethod]
        public async Task GetUser_InvalidEmail_ReturnsNull()
        {
            //To do
        }

       
    }
}
