using App.Deposits.Models;
using App.Deposits.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using App.Deposits.Exceptions;
using Microsoft.Extensions.Logging;
using App.Deposits.Filters;
namespace App.Deposits.Controller
{
    [Route("api/deposits")]
    [ApiController]
    [TypeFilter(typeof(DepositsExceptionFilter), Arguments = new object[] { nameof(DepositsController) })]
    public class DepositsController : ControllerBase
    {
        private readonly ILogger<DepositsController> logger;

        private readonly IDepositsManager depositsManager;
        public DepositsController(IDepositsManager depositsManager,ILogger<DepositsController> logger)
        {
            this.depositsManager = depositsManager;
            this.logger = logger;
        }

        [HttpPost]
        public ActionResult AddDeposit([FromBody]Deposit newDepositr)
        {
            logger.LogInformation($"Call AddDeposit with Name: {newDepositr.Name}, Interes rate: {newDepositr.InterestRate}");

            depositsManager.AddDeposit(newDepositr);
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Deposit>> GetAllDeposits()
        {
            logger.LogInformation($"Call GetAllDeposit");

            return Ok(depositsManager.GetAllDeposits());
        }

        [HttpGet("/{id}")]
        public ActionResult<Deposit> GetDepositById(int id)
        {
            logger.LogInformation($"Call GetDepositById(int id) with id: {id}");

            return Ok(depositsManager.GetDepositById(id));
        }

        [HttpGet("/{id}/calculate")]
        public ActionResult AccrualCalculation([FromRoute]int id, [FromQuery]Calculation calculation)
        {
            logger.LogInformation($"Call AccrualCalculation with id: {id}, StartSum: {calculation.StartSum}, FinishDate: {calculation.FinishDate}");

            return Ok(depositsManager.AccrualСalculation(id, calculation));
        }
    }
}
