using System.Data;
using MediatR;
using TredersToDoListApp.Application.Commands;
using TredersToDoListApp.Domain.Models;

namespace TredersToDoListApp.Infrastructure.Handlers;

public sealed class AddTaskCommandHandler : BaseHandler, IRequestHandler<AddTaskCommand, string>
{
    public async Task<string> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        var createdTask = new TaskTODO
        {
            Name = request.Name,
            Description = request.Description,
            Status = request.Status,
        };

        _taskcollection.Insert(createdTask);

        if (createdTask.Validate() == "false")
            throw new NoNullAllowedException();

        return createdTask.Name!;
    }
}
