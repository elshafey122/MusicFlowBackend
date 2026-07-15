using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Track.Commands.Model
{
    public class CreateDspsTrackCommand : IRequest<Response<string>>
    {
        public string TrackId { get; set; }
        public List<string> dspIds { get; set; }

    }
}
