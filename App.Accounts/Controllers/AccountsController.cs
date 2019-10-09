using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Accounts.Controllers
{
	[Route("api/example/accounts")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		// depedencies will be automatically resolved with used DI system
		readonly ILogger<AccountsController> _logger;
		readonly IAccountsManager _valuesManager;
		public AccountsController(
			ILogger<AccountsController> logger,
			IAccountsManager valuesManager)
		{
			_logger = logger;
			_valuesManager = valuesManager;
		}

		// GET api/example/values
		[HttpGet]
		public ActionResult<List<Account>> Get()
		{
			_logger.LogInformation("NOTHING");
			var serviceCallResult = _valuesManager.GetListAccounts();
			return serviceCallResult;
		}
		[HttpPut]
		public ActionResult<List<Account>> Put(int nomer)
		{
			_logger.LogInformation("Put");
			var putCallResult = _valuesManager.Zamina(nomer);
			return putCallResult;
		}
	}
}
