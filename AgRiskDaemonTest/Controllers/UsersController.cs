using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgRiskDaemonTest.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Graph;

namespace AgRiskDaemonTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        // GET: api/Users
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> GetAsync()
        {
            var usersCollection = await AuthenticationHelper.GetUsersAsync();
            var users = usersCollection.CurrentPage;

            return new JsonResult(usersCollection, new JsonSerializerSettings());

        }
    }
}
