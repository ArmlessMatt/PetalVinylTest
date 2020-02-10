using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Vinyl.Api.Constants;
using Vinyl.Domain.Interfaces;

namespace Vinyl.API.Controllers
{
    [ApiController]
    public class VinylController : ControllerBase
    {
        private IVinylService vinylService;

        public VinylController(IVinylService vinylService)
        {
            this.vinylService = vinylService;
        }

        [HttpGet]
        [Route("api/vinyl/randomvinyls")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<object> GetRandomVinyls([FromQuery(Name = "numberOfVinyls")] int numberOfVinyls = 5)
        {
            if (numberOfVinyls > 5 || numberOfVinyls < 1)
            {
                return BadRequest(new List<string> { Messages.VINYL_NUMBER_BETWEEN_ONE_AND_FIVE });
            }
            var result = vinylService.GetRandomVinyls(numberOfVinyls);

            if (result.IsSucces)
            {
                return Ok(result.Response);
            }
            return Ok(result.ErrorMessages);
        }
    }
}
