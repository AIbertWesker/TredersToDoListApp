using MediatR;

namespace TredersToDoListApp.Application.Commands;
public class DeleteTaskCommand : IRequest<string>
{
    public int Id { get; set; }
}
