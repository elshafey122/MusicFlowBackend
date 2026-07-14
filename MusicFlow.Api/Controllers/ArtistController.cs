using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicFlow.Application.Features.Artist.Commands.Model;
using MusicFlow.Application.Features.Artist.Queires.Model;

namespace MusicFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : BaseController
    {
        public ArtistController(IMediator mediator) : base(mediator)
        {
        }


        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArtists()
        {
            GetAllArtistsQuery GetAllArtistsQuery = new GetAllArtistsQuery();
            var response = await _mediator.Send(GetAllArtistsQuery);
            return Result(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateArtist([FromBody] CreateArtistCommand createArtistCommand)
        {
            var response = await _mediator.Send(createArtistCommand);
            return Result(response);
        }

    }
}
