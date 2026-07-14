using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Domain.Entites
{
    public class DSP
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<TrackDistribution> TrackDistributions { get; set; } = new List<TrackDistribution>();
    }
}
