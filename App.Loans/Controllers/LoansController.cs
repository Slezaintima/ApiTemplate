using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using App.Loans.Services;

namespace App.Loans.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        readonly LoansManager _valuesManager;
        public LoansController(
            LoansManager valuesManager)
        {
            _valuesManager = valuesManager;
        }

        [HttpGet("All")]
        public ActionResult<IEnumerable<string>> GetActiveLoans()
        {
            return _valuesManager.GetListActiveLoans().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetLeftMoneyByIdLoan(int id)
        {
            var serviceCallResult = _valuesManager.GetMoneyLeft(id).ToString();
            return serviceCallResult;
        }
    }
}

