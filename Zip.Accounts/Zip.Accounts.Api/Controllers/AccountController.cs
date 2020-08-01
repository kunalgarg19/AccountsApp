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
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet, Route("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAccounts()
        {
            return Ok(await _accountService.GetAccountList());
        }

        // POST: Account/Create
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(CreateAccountDto accountDto)
        {
            ActionResult response;
            var result = await _accountService.CreateAccount(accountDto);
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