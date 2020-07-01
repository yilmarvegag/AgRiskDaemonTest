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



        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>  
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Get(long id)
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
