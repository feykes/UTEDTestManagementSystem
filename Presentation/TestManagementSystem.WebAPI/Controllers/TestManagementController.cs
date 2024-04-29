using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestManagementSystem.Application.Features.Queries.Finding.FindingList;

namespace TestManagementSystem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetFindings() //proje id && faz id
        {
            var result = _mediator.Send(new FindingListQueryRequest());
            return Ok(result);
        }
    }
}
