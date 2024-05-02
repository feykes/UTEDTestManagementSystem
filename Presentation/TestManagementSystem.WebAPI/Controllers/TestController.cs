﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestManagementSystem.Application.Features.Commands.Test.TestCreate;
using TestManagementSystem.Application.Features.Queries.Finding.FindingList;
using TestManagementSystem.Application.Features.Queries.Test.TestList;

namespace TestManagementSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTests()
        {
            var result = await _mediator.Send(new TestListQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest(TestCreateCommandRequest testCreateCommandRequest)
        {
            await _mediator.Send(testCreateCommandRequest);
            return Ok();
        }
    }
}
