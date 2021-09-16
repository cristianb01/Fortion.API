using Fortion.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortion.API.Domain.Repositories
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<Warehouse>> ListAsync();
    }
}
