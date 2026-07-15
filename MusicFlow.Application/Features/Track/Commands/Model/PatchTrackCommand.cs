using MediatR;
using MusicFlow.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Track.Commands.Model
{
    public class PatchTrackCommand : IRequest<Response<TrackDto>>
    {
        public string trackId { get; set; }
        public string status { get; set; }
    }
}
