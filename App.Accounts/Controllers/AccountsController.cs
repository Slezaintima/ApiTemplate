using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Accounts.Controllers
{
	[Route("api/accounts")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		readonly IAccountsManager _accountsManager;
		public AccountsController(IAccountsManager accountsManager)
		{
			_accountsManager = accountsManager;
		}

		// GET api/example/values
		[HttpGet]
		public ActionResult<List<Account>> Get()
		{
			var serviceCallResult = _accountsManager.GetListAccounts();
			return serviceCallResult;
		}
		[Route("/BlockAccount")]
		[HttpPut]
		public ActionResult<List<Account>> BlockAccount(int nomer)
		{
			var putCallResponse = _accountsManager.BlockAccount(nomer);
			return putCallResponse;
		}
		[Route("/UnBlockAccount")]
		[HttpPut]
		public ActionResult<List<Account>> UnBlockAccount(int nomer)
		{
			var putCallResponse = _accountsManager.UnBlockAccount(nomer);
			return putCallResponse;
		}
	}
}
