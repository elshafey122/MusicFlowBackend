using MusicFlow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicFlow.Domain.Entites
{
    public class Track
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid ArtistId { get; set; }
        public string ISRC { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Genre { get; set; }
        public TrackStatus Status { get; set; }
        public Artist Artist { get; set; }
        public ICollection<TrackDistribution> TrackDistributions { get; set; } = new List<TrackDistribution>();
    }
}
