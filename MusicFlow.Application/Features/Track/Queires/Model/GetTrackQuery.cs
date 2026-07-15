using MediatR;
using MusicFlow.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Track.Queires.Model
{
    public class GetTrackQuery : IRequest<Response<TrackDspsDto>>
    {
        public string TrackId { get; set; }
    }
}
