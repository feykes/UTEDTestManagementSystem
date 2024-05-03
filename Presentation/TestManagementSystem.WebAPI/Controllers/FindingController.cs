using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestManagementSystem.Application.Features.Commands.Finding.FindingCreate;
using TestManagementSystem.Application.Features.Commands.Finding.FindingRemove;
using TestManagementSystem.Application.Features.Commands.Finding.FindingUpdate;
using TestManagementSystem.Application.Features.Queries.Finding.FindingList;

namespace TestManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FindingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFindings(FindingListQueryRequest findingListQueryRequest)
        {
            var data=await _mediator.Send(findingListQueryRequest);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFinding(FindingCreateCommandRequest findingCreateCommandRequest)
        {
            await _mediator.Send(findingCreateCommandRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFinding(FindingUpdateCommandRequest findingUpdateCommandRequest)
        {
            await _mediator.Send(findingUpdateCommandRequest);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFinding(FindingRemoveCommandRequest findingRemoveCommandRequest)
        {
            await _mediator.Send(findingRemoveCommandRequest);
            return Ok();
        }
    }
}
