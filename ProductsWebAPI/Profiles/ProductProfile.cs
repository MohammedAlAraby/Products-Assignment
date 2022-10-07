using AutoMapper;
using ProductsWebAPI.Entities;
using ProductsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {            
            CreateMap<ProductForManipulationDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
