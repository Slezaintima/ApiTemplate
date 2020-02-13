using App.Deposits.Models;
using App.Deposits.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Deposits.Controller
{
    [Route("api/deposits")]
    [ApiController]
    public class DepositsController : ControllerBase
    {
        private readonly IDepositsManager depositsManager;
        public DepositsController(IDepositsManager depositsManager)
        {
            this.depositsManager = depositsManager;
        }

        [HttpPost]
        public ActionResult AddDeposit([FromBody]Deposit newDepositr)
        {
            depositsManager.AddDeposit(newDepositr);
            return Ok();
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Deposit>> GetAllDeposits()
        {
            return Ok(depositsManager.GetAllDeposits());
        }

        [HttpGet("/{id}")]
        public ActionResult<Deposit> GetDepositById(int id)
        {
            return Ok(depositsManager.GetDepositById(id));
        }

        [HttpGet("/{id}/calculate")]
        public ActionResult AccrualCalculation([FromRoute]int id, [FromQuery]Calculation calculation)
        {
            return Ok(depositsManager.AccrualСalculation(id, calculation));
        }
    }
}
