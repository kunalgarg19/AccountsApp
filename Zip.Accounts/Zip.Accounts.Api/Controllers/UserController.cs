using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zip.Accounts.Core.Dtos;
using Zip.Accounts.Core.Services;

namespace Zip.Accounts.Api.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> GetUser([FromQuery] string email)
        {
            var response = await _userService.GetUser(email);
            if (response.Result != null)
            {
                return Ok(response);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet, Route("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetUsers()
        {
            return Ok(await _userService.GetUserList());
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(UserDto userDto)
        {
            ActionResult response;
            var result = await _userService.CreateUser(userDto);
            if (result.IsError)
            {
                response = BadRequest(result.ErrorMessage);
            }
            else
            {
                response = CreatedAtAction(nameof(Create), new { id = result.Result.Id }, result);
            }
            return response;
        }

    }
}