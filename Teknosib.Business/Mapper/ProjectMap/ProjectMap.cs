using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknosib.Business.Dto.ProjectDto;
using Teknosib.Entity.Models;

namespace Teknosib.Business.Mapper.ProjectMap
{
    public class ProjectMap : Profile
    {
        public ProjectMap()
        {
            //Output
            CreateMap<Project, ProjectDto>();
            //Input
            CreateMap<UpdateProjectDto, Project>();
            CreateMap<CreateProjectDto, Project>();


        }
    }
}
