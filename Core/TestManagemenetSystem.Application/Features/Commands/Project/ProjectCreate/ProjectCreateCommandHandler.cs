using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;

namespace TestManagementSystem.Application.Features.Commands.Project.ProjectCreate
{
    public class ProjectCreateCommandHandler : IRequestHandler<ProjectCreateCommandRequest, ProjectCreateCommandResponse>
    {
        private readonly IProjectWriteRepository _projectWriteRepository;

        public ProjectCreateCommandHandler(IProjectWriteRepository projectWriteRepository)
        {
            _projectWriteRepository = projectWriteRepository;
        }

        public async Task<ProjectCreateCommandResponse> Handle(ProjectCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Project()
            {
                Id = Guid.NewGuid(),
                ProjectName = request.ProjectName,
                Team = request.Team
            };

            await _projectWriteRepository.AddAsync(entity);
            await _projectWriteRepository.SaveAsync();
            return new();
        }
    }
}
