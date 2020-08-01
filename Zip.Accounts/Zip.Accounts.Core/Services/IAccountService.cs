using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zip.Accounts.Core.Common;
using Zip.Accounts.Core.Dtos;

namespace Zip.Accounts.Core.Services
{
    public interface IAccountService
    {
        Task<ServiceResponse<AccountDto>> CreateAccount(CreateAccountDto accountDto);

        Task<ServiceResponse<IList<AccountDto>>> GetAccountList();
        
    }
}
