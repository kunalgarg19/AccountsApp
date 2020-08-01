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
    public class AccountServiceUnitTests
    {
        private static Mock<IRepository<Account>> _accountRepositoryMock;
        private static Mock<IRepository<User>> _userRepositoryMock;
        private static Mock<IMapper> _mapperMock;
        private AccountService _accountService;

        private static IList<AccountDto> fakeAccountDtos = new List<AccountDto>() { new AccountDto() { } };

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            _accountRepositoryMock = new Mock<IRepository<Account>>();
            _userRepositoryMock = new Mock<IRepository<User>>();
            _mapperMock = new Mock<IMapper>();
            _mapperMock.SetReturnsDefault(fakeAccountDtos);
        }

        //[TestInitialize]
        //public void Setup()
        //{
        //    _accountService = new AccountService(_accountRepositoryMock.Object, _userRepositoryMock.Object, _mapperMock.Object);
        //}

        [TestMethod]
        public async Task GetAccountList_RunsSuccessfully()
        {
            _accountService = new AccountService(_accountRepositoryMock.Object, _userRepositoryMock.Object, _mapperMock.Object);
            var test = await _accountService.GetAccountList();

            Assert.AreEqual(test.Result.Count, 1);
            Assert.AreEqual(test.Result, fakeAccountDtos);
            _accountRepositoryMock.Verify(m => m.GetAllAsync(), Times.Once());
        }

        [TestMethod]
        public async Task CreateAccount_InputUserAccountAlreadyExists_AccountIsNotCreated()
        {
            var fakeAccount = new Account() { UserId = 1};
            var accountDto = new CreateAccountDto() { UserId = 1 };
            _accountRepositoryMock.Setup(a => a.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(fakeAccount));
            _userRepositoryMock.Setup(u => u.GetAsync(1)).Returns(Task.FromResult(new User() { MonthlySalary=2000, MonthlyExpenses=1000}));
            _mapperMock.Setup(m => m.Map<Account>(accountDto)).Returns(fakeAccount);
            _accountService = new AccountService(_accountRepositoryMock.Object, _userRepositoryMock.Object, _mapperMock.Object);
            
            var accountCreationResponse = await _accountService.CreateAccount(accountDto);           
            Assert.AreEqual(accountCreationResponse.Result, null);
        }

        [TestMethod]
        public async Task CreateAccount_InputUserIneligible_AccountIsNotCreated()
        {
            var fakeAccount = new Account() { UserId = 1 };
            var accountDto = new CreateAccountDto() { UserId = 1 };
            _accountRepositoryMock.Setup(a => a.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(fakeAccount));
            _userRepositoryMock.Setup(u => u.GetAsync(1)).Returns(Task.FromResult(new User() { MonthlySalary = 1000, MonthlyExpenses = 1000 }));
            _mapperMock.Setup(m => m.Map<Account>(accountDto)).Returns(fakeAccount);
            _accountService = new AccountService(_accountRepositoryMock.Object, _userRepositoryMock.Object, _mapperMock.Object);

            var accountCreationResponse = await _accountService.CreateAccount(accountDto);
            Assert.AreEqual(accountCreationResponse.IsError, true);
        }

        [TestMethod]
        public async Task CreateAccount_InputUserEligible_AccountIsCreated()
        {
            var fakeAccount = new Account() { UserId = 1 };
            var accountDto = new CreateAccountDto() { UserId = 1 };
            _accountRepositoryMock.Setup(a => a.GetAsync(It.IsAny<int>())).Returns(Task.FromResult(fakeAccount));
            _userRepositoryMock.Setup(u => u.GetAsync(1)).Returns(Task.FromResult(new User() { MonthlySalary = 2000, MonthlyExpenses = 1000 }));
            _mapperMock.Setup(m => m.Map<Account>(accountDto)).Returns(fakeAccount);
            _mapperMock.Setup(m => m.Map<AccountDto>(It.IsAny<Account>())).Returns(new AccountDto() { UserId =2});
            _accountService = new AccountService(_accountRepositoryMock.Object, _userRepositoryMock.Object, _mapperMock.Object);

            var accountCreationResponse = await _accountService.CreateAccount(accountDto);
            Assert.AreEqual(accountCreationResponse.Result.UserId, 2);
        }
    }
}
