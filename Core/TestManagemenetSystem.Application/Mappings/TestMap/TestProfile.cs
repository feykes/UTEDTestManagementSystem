using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.DTOs;
using TestManagementSystem.Domain.Entities;

namespace TestManagementSystem.Application.Mappings.TestMap
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<Test,TestDto>().ReverseMap();
        }
    }
}
