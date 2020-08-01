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
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserDto>> CreateUser(UserDto userDto)
        {
            ServiceResponse<UserDto> response= new ServiceResponse<UserDto>();
            try
            {
                response.Result = _mapper.Map<UserDto>(await _userRepository.AddAsync(_mapper.Map<User>(userDto)));
            }
            //Kunal: To Do: Catch this DbUpdateException in repository
            //and return an error from repository itself
            catch (Exception)
            {
                response.IsError = true;
                response.ErrorMessage = "Email id already in use";
            }
            return response;
        }

        public async Task<ServiceResponse<UserDto>> GetUser(string email)
        {
            var response = await _userRepository.GetAsync(u => !string.IsNullOrEmpty(email) && u.Email == email);
            return new ServiceResponse<UserDto>()
            {
                Result = _mapper.Map<UserDto>(response)
            };
        }

        public async Task<ServiceResponse<IList<UserDto>>> GetUserList()
        {
            var response = await _userRepository.GetAllAsync();
            return new ServiceResponse<IList<UserDto>>()
            {
                Result = _mapper.Map<IList<UserDto>>(response)
            };
        }
    }
}
