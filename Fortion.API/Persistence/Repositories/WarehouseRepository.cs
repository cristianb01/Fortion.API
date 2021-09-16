using Fortion.API.Domain.Models;
using Fortion.API.Domain.Repositories;
using Fortion.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortion.API.Persistence.Repositories
{
    public class WarehouseRepository : BaseRepository, IWarehouseRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseRepository(AppDbContext context, IUnitOfWork unitOfWork) : base (context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Warehouse>> ListAsync()
        {
            return await _context.Warehouses.Include(p => p.WarehouseType).ToListAsync();
        }
    }
}
