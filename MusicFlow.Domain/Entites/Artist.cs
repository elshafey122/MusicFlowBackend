using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicFlow.Domain.Entites
{
    public class Artist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public ICollection<Track> Tracks { get; set; } = new List<Track>();
    }
}
