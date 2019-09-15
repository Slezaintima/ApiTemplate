using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Example.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly ISomeService _service;
        readonly IAnotherService _anotherService;
        readonly ILogger<ValuesController> _logger;
        public ValuesController(
            ISomeService service,
            IAnotherService anotherService,
            ILogger<ValuesController> logger)
        {
            _service = service;
            _anotherService = anotherService;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _service.DoSmth();
            _anotherService.DoAnything();
            _logger.LogInformation("ZAZAZAZA");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
