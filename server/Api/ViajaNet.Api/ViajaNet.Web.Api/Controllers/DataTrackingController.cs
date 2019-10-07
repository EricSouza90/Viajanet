using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViajaNet.TrackingData.Domain.Commands;
using ViajaNet.TrackingData.Domain.Queries;
using ViajaNet.Web.Api.ViewModel;

namespace ViajaNet.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTrackingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DataTrackingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/DataTracking
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string ip, string pageName)
        {
            return Ok(await _mediator.Send(new DataTrackingQuery(ip, pageName)));
        }

        // POST: api/DataTracking
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DataTrackingViewModel data)
        {
            if (ModelState.IsValid)
                return Ok(await _mediator.Send(new DataTrackingAddQueueCommand(data.Convert())));
            else
                return BadRequest();
        }
    }
}
