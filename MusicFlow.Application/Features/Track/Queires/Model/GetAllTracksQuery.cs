using MediatR;
using MusicFlow.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Track.Queires.Model
{
    public class GetAllTracksQuery : IRequest<Response<List<TrackDto>>>
    {
        public string? ArtistId { get; set; }
        public string? Genre { get; set; }
        public string? Status { get; set; }

    }
}
