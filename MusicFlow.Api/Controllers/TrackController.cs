using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusicFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : BaseController
    {
        public TrackController(IMediator mediator) : base(mediator)
        {

        }
    }
}
