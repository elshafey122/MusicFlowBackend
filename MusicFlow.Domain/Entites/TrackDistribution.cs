using MusicFlow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Domain.Entites
{
    public class TrackDistribution
    {
        public Guid Id { get; set; }
        public Guid TrackId { get; set; }
        public Guid DspId { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DistributionStatus Status { get; set; }
        public Track Track { get; set; } = null!;
        public DSP Dsp { get; set; } = null!;
    }
}
