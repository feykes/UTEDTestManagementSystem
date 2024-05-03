using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;

namespace TestManagementSystem.Application.Features.Commands.Test.TestUpdate
{
    public class TestUpdateCommandHandler : IRequestHandler<TestUpdateCommandRequest, TestUpdateCommandResponse>
    {
        private readonly ITestReadRepository _testReadRepository;
        private readonly ITestWriteRepository _testWriteRepository;

        public TestUpdateCommandHandler(ITestReadRepository testReadRepository, ITestWriteRepository testWriteRepository)
        {
            _testReadRepository = testReadRepository;
            _testWriteRepository = testWriteRepository;
        }

        public async Task<TestUpdateCommandResponse> Handle(TestUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var test=await _testReadRepository.GetByIdAsync(request.Id);
            test.ProjectId = request.ProjectId;
            test.PhaseNo = request.PhaseNo;
            test.IsActive = request.IsActive;
            await _testWriteRepository.SaveAsync();
            return new();
        }
    }
}
