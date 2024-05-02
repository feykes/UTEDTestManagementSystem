using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;

namespace TestManagementSystem.Application.Features.Commands.Finding.FindingCreate
{
    public class FindingCreateCommandHandler : IRequestHandler<FindingCreateCommandRequest, FindingCreateCommandResponse>
    {
        private readonly IFindingWriteRepository _findingWriteRepository;

        public FindingCreateCommandHandler(IFindingWriteRepository findingWriteRepository)
        {
            _findingWriteRepository = findingWriteRepository;
        }

        public async Task<FindingCreateCommandResponse> Handle(FindingCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Finding()
            {
                Id=Guid.NewGuid(),
                ImportanceLevel=request.ImportanceLevel,
                Status=request.Status,
                Description=request.Description,
                Date=DateTime.Now,
                Note=request.Note,
                TestId=request.TestId
            };

            await _findingWriteRepository.AddAsync(entity);
            await _findingWriteRepository.SaveAsync();
            return new();
        }
    }
}
