﻿using System;
using AutoMapper;
using Cars.DTOs;
using Cars.Models;

namespace Cars.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Car, CarDTO>();
        }
    }
}

