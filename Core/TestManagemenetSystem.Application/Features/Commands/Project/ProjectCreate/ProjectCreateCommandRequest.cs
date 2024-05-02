using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Domain.Entities;

namespace TestManagementSystem.Application.Features.Commands.Project.ProjectCreate
{
    public class ProjectCreateCommandRequest : IRequest<ProjectCreateCommandResponse>
    {
        public string ProjectName { get; set; }
        public Team Team { get; set; }
    }
}
