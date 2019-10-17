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
            // depedencies will be automatically resolved with used DI system
            readonly IPaymentsManager _paymentsManager;
            public PaymentsController(IPaymentsManager paymentsManager)
            {
            _paymentsManager = paymentsManager;
            }

            // GET api/example/values
            [HttpGet] 
            [Route("/filtration")]
            public ActionResult<List<Payment>> Filtration(string Status)
            {
                var serviceCallResult = _paymentsManager.Filtration(Status);
                return serviceCallResult;
            }
        [HttpPost]
        [Route("/createpayment")]
        public ActionResult<List<Payment>> CreatePayment(int ID, string Status)
        {
            var serviceCallResult = _paymentsManager.CreatePayment(ID,Status);
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
