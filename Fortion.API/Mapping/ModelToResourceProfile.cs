using AutoMapper;
using Fortion.API.Domain.Models;
using Fortion.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortion.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Warehouse, WarehouseResource>()
                .ForMember(p => p.Length, opt => opt.MapFrom(p => p.WarehouseType.Length))
                .ForMember(p => p.Width, opt => opt.MapFrom(p => p.WarehouseType.Width));
        }
    }
}
