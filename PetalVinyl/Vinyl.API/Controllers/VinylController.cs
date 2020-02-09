using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Vinyl.API.Controllers
{
    [ApiController]
    public class VinylController : ControllerBase
    {
        [HttpGet]
        [Route("api/vinyl/randomvinyls")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> GetRandomVinyls([FromQuery(Name = "numberOfVinyls")] int numberOfVinyls = 5)
        {
            return numberOfVinyls;
        }
    }
}
