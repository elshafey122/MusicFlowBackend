using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicFlow.Api.Request;
using MusicFlow.Application.Features.Track.Commands.Model;
using MusicFlow.Application.Features.Track.Queires.Model;

namespace MusicFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : BaseController
    {
        public TrackController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTracks([FromQuery] string? ArtistId, string? Genre, string? Status)
        {
            GetAllTracksQuery getAllTracksQuery = new GetAllTracksQuery
            {
                ArtistId = ArtistId,
                Genre = Genre,
                Status = Status
            };
            var response = await _mediator.Send(getAllTracksQuery);
            return Result(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTrack(string id)
        {
            GetTrackQuery GetTrackQuery = new GetTrackQuery
            {
                TrackId = id
            };
            var response = await _mediator.Send(GetTrackQuery);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStatus(string id , string status)
        {
            PatchTrackCommand patchTrackCommand = new PatchTrackCommand
            {
                trackId = id,
                status = status
            };
            var response = await _mediator.Send(patchTrackCommand);
            return Result(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTrack([FromBody] CreateTrackCommand createTrackCommand)
        {
            var response = await _mediator.Send(createTrackCommand);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{id}/Distribute")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateDspsTrack(string id,[FromBody] List<string> dspIds)
        {
            CreateDspsTrackCommand CreateDspTracksCommand = new CreateDspsTrackCommand
            {
                TrackId = id,
                dspIds = dspIds
            };
            var response = await _mediator.Send(CreateDspTracksCommand);
            return Result(response);
        }
    }
}
