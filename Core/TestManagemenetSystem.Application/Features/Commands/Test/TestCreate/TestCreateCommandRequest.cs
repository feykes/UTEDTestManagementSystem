using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementSystem.Application.Features.Commands.Test.TestCreate
{
    public class TestCreateCommandRequest : IRequest<TestCreateCommandResponse>
    {
        public Guid ProjectId { get; set; }
        public byte PhaseNo { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
