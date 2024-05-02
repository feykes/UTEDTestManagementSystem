using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;
using TestManagementSystem.Domain.Entities;

namespace TestManagementSystem.Application.Features.Commands.Test.TestCreate
{
    public class TestCreateCommandHandler : IRequestHandler<TestCreateCommandRequest, TestCreateCommandResponse>
    {
        private readonly ITestWriteRepository _testWriteRepository;

        public TestCreateCommandHandler(ITestWriteRepository testWriteRepository)
        {
            _testWriteRepository = testWriteRepository;
        }

        public async Task<TestCreateCommandResponse> Handle(TestCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Test()
            {
                Id=Guid.NewGuid(),
                ProjectId=request.ProjectId,
                PhaseNo=request.PhaseNo,
                IsActive=request.IsActive
            };

            await _testWriteRepository.AddAsync(entity);
            await _testWriteRepository.SaveAsync();
            return new();
        }
    }
}
