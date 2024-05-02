using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Domain.Entities;

namespace TestManagementSystem.Application.Features.Commands.Finding.FindingCreate
{
    public class FindingCreateCommandRequest : IRequest<FindingCreateCommandResponse>
    {
        public ImportanceLevel ImportanceLevel { get; set; }
        public Status Status { get; set; }
        public string Description { get; set; }
        public string? Note { get; set; }
        public Guid TestId { get; set; }
    }
}
