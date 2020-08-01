using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zip.Accounts.Core.Common;
using Zip.Accounts.Core.Dtos;
using Zip.Accounts.Core.Entities;
using Zip.Accounts.Core.Repositories;
using Zip.Accounts.Core.Services;

namespace Zip.Accounts.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public AccountService(IRepository<Account> accountRepository, IRepository<User> userRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse<AccountDto>> CreateAccount(CreateAccountDto accountDto)
        {
            var response = new ServiceResponse<AccountDto>();
            if (accountDto.UserId> 0)
            {
                //Kunal: To Do: Move below logic to a different business rules or service
                //Also, if using DDD, would be beneficial for this logic
                var user = await _userRepository.GetAsync(accountDto.UserId);
               
                if(user.MonthlySalary - user.MonthlyExpenses >= 1000)
                {
                    var existingAccount = await _accountRepository.GetAsync(a => a.UserId == user.Id);
                    if(existingAccount == null)
                    {
                        var account = _mapper.Map<Account>(accountDto);
                        account.CreditAmount = 1000;
                        account.CreditAvailable = 1000;
                        account.IsActive = true;
                        var addedAccount = await _accountRepository.AddAsync(account);
                        response.Result = _mapper.Map<AccountDto>(addedAccount);
                    }
                    else
                    {
                        response.IsError = true;
                        response.ErrorMessage = "Account already exists.";
                    }
                }
                else
                {
                    response.IsError = true;
                    response.ErrorMessage = "Applied credit limit does not meet the eligibility.";
                }
            }
            return response;
            
        }

        public async Task<ServiceResponse<IList<AccountDto>>> GetAccountList()
        {
            var response = await _accountRepository.GetAllAsync();
            return new ServiceResponse<IList<AccountDto>>()
            {
                Result = _mapper.Map<IList<AccountDto>>(response)
            };
        }
    }
}
