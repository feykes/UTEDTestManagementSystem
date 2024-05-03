using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementSystem.Application.Features.Commands.Test.TestUpdate
{
    public class TestUpdateCommandRequest : IRequest<TestUpdateCommandResponse>
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public byte PhaseNo { get; set; }
        public bool IsActive { get; set; }
    }
}
