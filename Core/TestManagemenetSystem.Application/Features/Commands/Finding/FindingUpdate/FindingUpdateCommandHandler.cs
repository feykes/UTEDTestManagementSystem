using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.Repositories;

namespace TestManagementSystem.Application.Features.Commands.Finding.FindingUpdate
{
    public class FindingUpdateCommandHandler : IRequestHandler<FindingUpdateCommandRequest, FindingUpdateCommandResponse>
    {
        private readonly IFindingReadRepository _findingReadRepository;
        private readonly IFindingWriteRepository _findingWriteRepository;

        public FindingUpdateCommandHandler(IFindingReadRepository findingReadRepository, IFindingWriteRepository findingWriteRepository)
        {
            _findingReadRepository = findingReadRepository;
            _findingWriteRepository = findingWriteRepository;
        }

        public async Task<FindingUpdateCommandResponse> Handle(FindingUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var finding=await _findingReadRepository.GetByIdAsync(request.Id);
            finding.ImportanceLevel = request.ImportanceLevel;
            finding.Status = request.Status;
            finding.Description = request.Description;
            finding.Date= DateTime.UtcNow;
            finding.Note = request.Note;
            await _findingWriteRepository.SaveAsync();
            return new();
        }
    }
}
