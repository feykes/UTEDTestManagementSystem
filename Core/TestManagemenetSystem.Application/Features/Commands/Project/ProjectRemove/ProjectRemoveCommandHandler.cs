using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;

namespace TestManagementSystem.Application.Features.Commands.Project.ProjectRemove
{
    public class ProjectRemoveCommandHandler : IRequestHandler<ProjectRemoveCommandRequest, ProjectRemoveCommandResponse>
    {
        private readonly IProjectWriteRepository _projectWriteRepository;

        public ProjectRemoveCommandHandler(IProjectWriteRepository projectWriteRepository)
        {
            _projectWriteRepository = projectWriteRepository;
        }

        public async Task<ProjectRemoveCommandResponse> Handle(ProjectRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            await _projectWriteRepository.RemoveAsync(request.Id);
            await _projectWriteRepository.SaveAsync();
            return new();
        }
    }
}
