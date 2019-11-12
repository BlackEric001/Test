using AutoMapper;
using Infrastructure.DTO;
using Infrastucture.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<InputModel, CalculationModel>();
        }
    }
}
