using Automobile.Application.Data;
using Automobile.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Automobile.Web.Controllers
{
    [Route("data")]
    [Authorize]
    public class DataProviderController : ControllerBase
    {
        private readonly IDataService _dataService;

        public DataProviderController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
        [Authorize(Roles = "Manager")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Vehicle>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var user = User;
            return Ok(_dataService.GetData());
        }
    }
}
