﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagementSystem.Application.Features.Commands.Finding.FindingRemove
{
    public class FindingRemoveCommandRequest : IRequest<FindingRemoveCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
