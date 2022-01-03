using AutoMapper;
using ResimProjesi.Entities;
using ResimProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResimProjesi.Mapping
{
    public class ProductMapping:Profile
    {
        public ProductMapping()
        {
            CreateMap<AddProduct,Product>().ReverseMap();
        }
    }
}
