using MediatR;
using MusicFlow.Application.Features.Artist.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Artist.Commands.Model
{
    public class CreateArtistCommand : IRequest<Response<string>>
    {
        
    }
}
