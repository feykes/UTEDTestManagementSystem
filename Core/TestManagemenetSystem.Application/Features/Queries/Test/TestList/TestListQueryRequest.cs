using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagementSystem.Application.DTOs;
using TestManagementSystem.Domain.Entities;

namespace TestManagementSystem.Application.Features.Queries.Test.TestList
{
    public class TestListQueryRequest : IRequest<List<TestDto>>
    {
    }
}
