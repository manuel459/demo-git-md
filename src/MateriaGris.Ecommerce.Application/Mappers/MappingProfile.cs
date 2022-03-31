using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MateriaGris.Ecommerce.Application.Dtos;
using MateriaGris.Ecommerce.Domain.Entities;

namespace MateriaGris.Ecommerce.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //ReverseMap doble sentido
            CreateMap<CustomerDto, Customer>().ReverseMap();
        }
    }
}
