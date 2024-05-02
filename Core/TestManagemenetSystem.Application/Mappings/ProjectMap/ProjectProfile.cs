using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.DTOs;
using TestManagementSystem.Domain.Entities;

namespace TestManagementSystem.Application.Mappings.ProjectMap
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
        }
    }
}
