using Fortion.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortion.API.Domain.Services
{
    public interface IWarehouseService
    {
        Task<IEnumerable<Warehouse>> ListAsync();
    }
}
