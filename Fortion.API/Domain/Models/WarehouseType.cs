using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortion.API.Domain.Models
{
    public class WarehouseType
    {
        public int Id { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public ICollection<Warehouse> Warehouses { get; set; }
    }
}
