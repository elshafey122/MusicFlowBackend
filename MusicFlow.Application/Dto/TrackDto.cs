using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Application.Dto
{
    public class TrackDto
    {
        public Guid Id { get; set; }
        public string ArtistName { get; set; }
        public string Title { get; set; }
        public string ISRC { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }
    }
}
