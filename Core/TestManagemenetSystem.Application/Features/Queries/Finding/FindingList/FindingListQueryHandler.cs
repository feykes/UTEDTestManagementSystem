using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;

namespace TestManagementSystem.Application.Features.Queries.Finding.FindingList
{
    public class FindingListQueryHandler : IRequestHandler<FindingListQueryRequest, List<Domain.Entities.Finding>>
    {
        private readonly IFindingReadRepository _findingReadRepository;

        public FindingListQueryHandler(IFindingReadRepository findingReadRepository)
        {
            _findingReadRepository = findingReadRepository;
        }

        public async Task<List<Domain.Entities.Finding>> Handle(FindingListQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _findingReadRepository.GetWhere(f => f.TestId == request.TestId, true).ToListAsync();
            return data;
        }
    }
}
