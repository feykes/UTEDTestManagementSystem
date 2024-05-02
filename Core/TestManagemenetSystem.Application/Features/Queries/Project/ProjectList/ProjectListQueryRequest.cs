using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.DTOs;

namespace TestManagementSystem.Application.Features.Queries.Project.ProjectList
{
    public class ProjectListQueryRequest : IRequest<List<ProjectDto>>
    {
    }
}
