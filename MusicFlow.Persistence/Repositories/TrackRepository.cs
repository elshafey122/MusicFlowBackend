using MusicFlow.Domain.Entites;
using MusicFlow.Persistence.IRepositories;
using ProductService.Persistence;
using ProductService.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MusicFlow.Persistence.Repositories
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        public TrackRepository(AppDbContext context) : base(context)
        {

        }
    }
}
