using MusicFlow.Domain.Entites;
using MusicFlow.Persistence.IRepositories;
using ProductService.Persistence;
using ProductService.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Persistence.Repositories
{
    public class TrackDistRepository : Repository<TrackDistribution>, ITrackDistRepository
    {
        private readonly AppDbContext _context;
        public TrackDistRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
