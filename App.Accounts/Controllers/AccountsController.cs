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
		public void BlockAccount(int number)
		{
			_accountsManager.BlockAccount(number);
		}
		[Route("/UnBlockAccount")]
		[HttpPut]
		public void UnBlockAccount(int number)
		{
			_accountsManager.UnBlockAccount(number);
		}
	}
}
