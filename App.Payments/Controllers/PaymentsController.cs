using App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Payments.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
            readonly IPaymentsManager _paymentsManager;
            public PaymentsController(IPaymentsManager paymentsManager)
            {
            _paymentsManager = paymentsManager;
            }

            [HttpGet] 
            [Route("/getpbystat")]
        public IEnumerable<Payment> GetPaymentsByStatus(string Status)
        {
            var serviceCallResult = _paymentsManager.GetPaymentsByStatus(Status);
            return serviceCallResult;
        }
        [HttpPost]
        [Route("/createpayment")]
        public ActionResult<List<Payment>> CreatePayment(int p_number, string Status)
        {
            var serviceCallResult = _paymentsManager.CreatePayment(p_number, Status);
            return serviceCallResult;
        }
        [HttpGet]
        public ActionResult<List<Payment>> GetListPayments()
        {
            var serviceCallResult = _paymentsManager.GetListPayments();
            return serviceCallResult;
        }
    }
}
