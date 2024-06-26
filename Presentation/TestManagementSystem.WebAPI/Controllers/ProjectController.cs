﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestManagementSystem.Application.Features.Commands.Project.ProjectCreate;
using TestManagementSystem.Application.Features.Commands.Project.ProjectRemove;
using TestManagementSystem.Application.Features.Commands.Project.ProjectUpdate;
using TestManagementSystem.Application.Features.Queries.Project.ProjectList;

namespace TestManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var data = await _mediator.Send(new ProjectListQueryRequest());
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectCreateCommandRequest projectCreateCommandRequest)
        {
            await _mediator.Send(projectCreateCommandRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(ProjectUpdateCommandRequest projectUpdateCommandRequest)
        {
            await _mediator.Send(projectUpdateCommandRequest);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProject(ProjectRemoveCommandRequest projectRemoveCommandRequest)
        {
            await _mediator.Send(projectRemoveCommandRequest);
            return Ok();
        }
    }
}
