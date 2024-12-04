using MediatR;

#pragma warning disable CS8618
namespace TredersToDoListApp.Application.Commands;

public class AddTaskCommand : IRequest<string>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
}
