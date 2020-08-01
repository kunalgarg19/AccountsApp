using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zip.Accounts.Core.Common;
using Zip.Accounts.Core.Dtos;

namespace Zip.Accounts.Core.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<UserDto>> CreateUser(UserDto userDto);

        Task<ServiceResponse<UserDto>> GetUser(string email);

        Task<ServiceResponse<IList<UserDto>>> GetUserList();
    }
}
