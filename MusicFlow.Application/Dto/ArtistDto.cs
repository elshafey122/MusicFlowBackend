using MusicFlow.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Dto
{
    public class ArtistDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public IEnumerable<TrackDto>? Tracks { get; set; } = new List<TrackDto>();
    }
}
