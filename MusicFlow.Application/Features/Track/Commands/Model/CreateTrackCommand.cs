using MediatR;
using MusicFlow.Application.Dto;
using MusicFlow.Domain.Entites;
using MusicFlow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Features.Track.Commands.Model
{
    public class CreateTrackCommand : IRequest<Response<TrackDto>>
    {
        public string Title { get; set; }
        public Guid ArtistId { get; set; }
        public string ISRC { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }
    }
}
