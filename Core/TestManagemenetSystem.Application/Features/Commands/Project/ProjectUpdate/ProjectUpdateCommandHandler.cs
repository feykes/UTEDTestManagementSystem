using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;

namespace TestManagementSystem.Application.Features.Commands.Project.ProjectUpdate
{
    public class ProjectUpdateCommandHandler : IRequestHandler<ProjectUpdateCommandRequest, ProjectUpdateCommandResponse>
    {
        private readonly IProjectReadRepository _projectReadRepository;
        private readonly IProjectWriteRepository _projectWriteRepository;

        public ProjectUpdateCommandHandler(IProjectReadRepository projectReadRepository, IProjectWriteRepository projectWriteRepository)
        {
            _projectReadRepository = projectReadRepository;
            _projectWriteRepository = projectWriteRepository;
        }

        public async Task<ProjectUpdateCommandResponse> Handle(ProjectUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var project=await _projectReadRepository.GetByIdAsync(request.Id);
            project.ProjectName=request.ProjectName;
            project.Team=request.Team;
            await _projectWriteRepository.SaveAsync();
            return new();
        }
    }
}
