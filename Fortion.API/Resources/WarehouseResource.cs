using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortion.API.Resources
{
    public class WarehouseResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
    }
}
