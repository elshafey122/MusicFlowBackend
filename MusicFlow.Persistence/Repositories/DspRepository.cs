using MusicFlow.Domain.Entites;
using MusicFlow.Persistence.IRepositories;
using ProductService.Persistence;
using ProductService.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicFlow.Persistence.Repositories
{
    public class DspRepository : Repository<DSP>, IDspRepository
    {
        private readonly AppDbContext _context;
        public DspRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
