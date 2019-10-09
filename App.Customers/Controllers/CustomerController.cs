using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Customers.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController:ControllerBase
    {
        readonly ILogger<CustomerController> _logger;
        readonly ICustomersManager _customersManager;

        public CustomerController(ILogger<CustomerController> logger,ICustomersManager customersManager)
        {
            _logger = logger;
            _customersManager = customersManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
           _logger.LogInformation("NOTHING");
            if (_customersManager.GetCustomers() == null)
                return NotFound();
            else
            {
                var serviceCallResult = _customersManager.GetCustomers().ToList();
                return serviceCallResult;
            }
        }
        [HttpGet]
        public ActionResult<string> GetById( int id)
        {
            _logger.LogInformation("NOTHING");
            var serviceCallResult = _customersManager.GetCustomer(id);
            return serviceCallResult;
        }


        [HttpPost]
        public ActionResult Add(string customer)
        {
            _logger.LogInformation("NOTHING");
            _customersManager.Add(customer);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update(string oldCustomer, string newCustomer)
        {
            _logger.LogInformation("NOTHING");
            if (_customersManager.Update(oldCustomer, newCustomer))
                return Ok();
            else return NotFound();
        }
    }
}
