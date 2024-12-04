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
    private readonly ISender _mediator; // <3 <3 <3 <3 <3

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetTaskByIdQuery { Id = id });

            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An unexpected error occurred.", Details = ex.Message });
        }
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

    [HttpDelete]
    public async Task<IActionResult> DeleteTask(int id)
    {
        try
        {
            var result = await _mediator.Send(new DeleteTaskCommand { Id = id });
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound(id);
        }
        catch (Exception ex) 
        { 
            return UnprocessableEntity(ex.Message);
        }

    }
}
