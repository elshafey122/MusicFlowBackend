using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MusicFlow.Api
{
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
           _mediator = mediator;   
        }

        protected ObjectResult Result<T>(Response<T> response)
        {
            switch (response.StatusCode)
            {
                case (HttpStatusCode.OK):
                    return new OkObjectResult(response);
                    break;
                case (HttpStatusCode.Unauthorized):
                    return new UnauthorizedObjectResult(response);
                    break;
                case (HttpStatusCode.NotFound):
                    return new NotFoundObjectResult(response);
                    break;
                case (HttpStatusCode.BadRequest):
                    return new BadRequestObjectResult(response);
                    break;
                case (HttpStatusCode.Created):
                    return new CreatedResult(string.Empty, response);
                    break;
                case HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);
            }


        }
    }
}
