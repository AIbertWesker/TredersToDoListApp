using MediatR;

namespace TredersToDoListApp.Application.Commands;

public class UpdateTaskCommand : IRequest<string>
{
    public int Id { get; set; }
    public string? Status { get; set; }
}
