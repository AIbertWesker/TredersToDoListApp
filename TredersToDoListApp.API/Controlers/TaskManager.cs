using MediatR;
using Microsoft.AspNetCore.Mvc;
using TredersToDoListApp.API.DTOs;
using TredersToDoListApp.Application.Commands;
using TredersToDoListApp.Application.Queries;
using TredersToDoListApp.Domain.Models;

namespace TredersToDoListApp.API.Controlers;

[ApiController]
[Route("api/tasks")]
public class TaskManager : ControllerBase
{
    //private readonly TaskeManager taskManager = new();
    private readonly ISender _mediator;

    public TaskManager(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var result = await _mediator.Send(new GetTaskListQuery { });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddTask([FromBody] AddTaskDTO task)
    {
        try
        {
            var result = await _mediator.Send(new AddTaskCommand
            {
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
            });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return UnprocessableEntity(ex.Message);
        }
    }
}
