using Fortion.API.Domain.Models;
using Fortion.API.Domain.Repositories;
using Fortion.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortion.API.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        public async Task<IEnumerable<Warehouse>> ListAsync()
        {
            return await _warehouseRepository.ListAsync();
        }
    }
}
