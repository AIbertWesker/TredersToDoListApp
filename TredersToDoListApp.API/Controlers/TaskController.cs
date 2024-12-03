using MediatR;
using Microsoft.AspNetCore.Mvc;
using TredersToDoListApp.Application.Queries;
using TredersToDoListApp.Domain.Models;

namespace TredersToDoListApp.API.Controlers;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{
    //private readonly TaskeManager taskManager = new();
    private readonly ISender _mediator;

    public TaskController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var chuj2 = await _mediator.Send(new GetTaskListQuery { });
        return Ok(chuj2);
    }
}
