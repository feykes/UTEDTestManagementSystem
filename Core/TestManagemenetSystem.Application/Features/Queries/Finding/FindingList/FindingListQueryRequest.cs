using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Domain.Entities;

namespace TestManagementSystem.Application.Features.Queries.Finding.FindingList
{
    public class FindingListQueryRequest : IRequest<List<Domain.Entities.Finding>>
    {
        public Guid TestId { get; set; }
    }
}
