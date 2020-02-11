using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgRiskDaemonTest.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AgRiskDaemonTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {

        private readonly ILogger<FilesController> _logger;
        public FilesController(ILogger<FilesController> logger)
        {
            _logger = logger;
        }


        // GET: api/Files
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> Get()
        {
            var filesCollection = await AuthenticationHelper.GetFilesAsync();

            return new JsonResult(filesCollection, new JsonSerializerSettings());
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("api/workbook")]
        public async Task<ActionResult> GetWorkbook()
        {
            var workbook = await AuthenticationHelper.GetWorkbookAsync("");

            return new JsonResult(workbook, new JsonSerializerSettings());
        }

        // GET: api/Files/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST: api/Files
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Files/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
