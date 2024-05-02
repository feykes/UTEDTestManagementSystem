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

        public Task<FindingCreateCommandResponse> Handle(FindingCreateCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
