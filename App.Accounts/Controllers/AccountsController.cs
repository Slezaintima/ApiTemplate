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
		readonly IAccountsManager _valuesManager;
		public AccountsController(IAccountsManager valuesManager)
		{
			_valuesManager = valuesManager;
		}

		// GET api/example/values
		[HttpGet]
		public ActionResult<List<Account>> Get()
		{
			var serviceCallResult = _valuesManager.GetListAccounts();
			return serviceCallResult;
		}
		[Route("/BlockAccount")]
		[HttpPut]
		public ActionResult<List<Account>> BlockAccount(int nomer)
		{
			var putCallResponse = _valuesManager.BlockAccount(nomer);
			return putCallResponse;
		}
		[Route("/UnBlockAccount")]
		[HttpPut]
		public ActionResult<List<Account>> UnBlockAccount(int nomer)
		{
			var putCallResponse = _valuesManager.UnBlockAccount(nomer);
			return putCallResponse;
		}
	}
}
