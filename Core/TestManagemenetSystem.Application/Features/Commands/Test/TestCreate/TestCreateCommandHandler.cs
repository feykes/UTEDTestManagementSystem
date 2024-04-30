using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementSystem.Application.Features.Commands.Test.TestCreate
{
    public class TestCreateCommandHandler : IRequestHandler<TestCreateCommandRequest, TestCreateCommandResponse>
    {
        public Task<TestCreateCommandResponse> Handle(TestCreateCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
