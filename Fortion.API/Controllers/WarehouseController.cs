using AutoMapper;
using Fortion.API.Domain.Models;
using Fortion.API.Domain.Services;
using Fortion.API.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortion.API.Controllers
{
    [Route("/api/[controller]")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;

        public WarehouseController(IWarehouseService warehouseService, IMapper mapper)
        {
            _warehouseService = warehouseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            var warehouses = await _warehouseService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Warehouse>, IEnumerable<WarehouseResource>>(warehouses);
            return warehouses;
        }
    }
}
