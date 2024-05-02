using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.DTOs;
using TestManagementSystem.Application.Repositories;

namespace TestManagementSystem.Application.Features.Queries.Project.ProjectList
{
    public class ProjectListQueryHandler : IRequestHandler<ProjectListQueryRequest, List<ProjectDto>>
    {
        private readonly IProjectReadRepository _projectReadRepository;
        private readonly IMapper _mapper;

        public ProjectListQueryHandler(IProjectReadRepository projectReadRepository, IMapper mapper)
        {
            _projectReadRepository = projectReadRepository;
            _mapper = mapper;
        }

        public async Task<List<ProjectDto>> Handle(ProjectListQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _projectReadRepository.GetAllAsync();
            return _mapper.Map<List<ProjectDto>>(data);
        }
    }
}
