using AutoMapper;
using BoookStoreDatabase2.BLL.Models.DTO;
using BoookStoreDatabase2.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoookStoreDatabase2.DAL.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductsDTO>();
        }

    }
}
