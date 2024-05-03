using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;

namespace TestManagementSystem.Application.Features.Commands.Finding.FindingRemove
{
    public class FindingRemoveCommandHandler : IRequestHandler<FindingRemoveCommandRequest, FindingRemoveCommandResponse>
    {
        private readonly IFindingWriteRepository _findingWriteRepository;

        public FindingRemoveCommandHandler(IFindingWriteRepository findingWriteRepository)
        {
            _findingWriteRepository = findingWriteRepository;
        }

        public async Task<FindingRemoveCommandResponse> Handle(FindingRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            await _findingWriteRepository.RemoveAsync(request.Id);
            return new();
        }
    }
}
