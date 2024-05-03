using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;

namespace TestManagementSystem.Application.Features.Commands.Test.TestRemove
{
    public class TestRemoveCommandHandler : IRequestHandler<TestRemoveCommandRequest, TestRemoveCommandResponse>
    {
        private readonly ITestWriteRepository _testWriteRepository;
        private readonly IFindingReadRepository _findingReadRepository;
        private readonly IFindingWriteRepository _findingWriteRepository;

        public TestRemoveCommandHandler(ITestWriteRepository testWriteRepository, IFindingReadRepository findingReadRepository, IFindingWriteRepository findingWriteRepository)
        {
            _testWriteRepository = testWriteRepository;
            _findingReadRepository = findingReadRepository;
            _findingWriteRepository = findingWriteRepository;
        }

        public async Task<TestRemoveCommandResponse> Handle(TestRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _findingReadRepository.GetWhere(f => f.TestId == request.Id, true).ToListAsync();

            if (entity != null)
            {
                _findingWriteRepository.RemoveRange(entity);
                await _findingWriteRepository.SaveAsync();
            }

            await _testWriteRepository.RemoveAsync(request.Id);
            await _testWriteRepository.SaveAsync();
            return new();
        }
    }
}
