﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementSystem.Application.Features.Commands.Test.TestRemove
{
    public class TestRemoveCommandRequest : IRequest<TestRemoveCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
