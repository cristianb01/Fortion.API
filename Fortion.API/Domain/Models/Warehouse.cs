using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortion.API.Domain.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int WarehouseTypeId { get; set; }
        public WarehouseType WarehouseType { get; set; }
    }
}
