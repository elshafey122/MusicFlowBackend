using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicFlow.Application.Features.Auth.Commands.Model;

namespace MusicFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
            
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand RegisterUserCommand)
        {
            var result = await _mediator.Send(RegisterUserCommand);
            return Ok(result);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand LoginCommand)
        {
            var result = await _mediator.Send(LoginCommand);
            return Ok(result);
        }


    }
}
