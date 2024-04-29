using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.DTOs;
using TestManagementSystem.Application.Repositories;

namespace TestManagementSystem.Application.Features.Queries.Test.TestList
{
    public class TestListQueryHandler : IRequestHandler<TestListQueryRequest, List<TestDto>>
    {
        private readonly ITestReadRepository _repository;
        private readonly IMapper _mapper;

        public TestListQueryHandler(ITestReadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TestDto>> Handle(TestListQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<TestDto>>(data);
        }
    }
}
