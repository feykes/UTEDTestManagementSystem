using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementSystem.Application.Features.Commands.Project.ProjectRemove
{
    public class ProjectRemoveCommandRequest : IRequest<ProjectRemoveCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
