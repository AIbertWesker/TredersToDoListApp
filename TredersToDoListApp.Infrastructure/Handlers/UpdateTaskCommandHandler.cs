using MediatR;
using TredersToDoListApp.Application.Commands;

namespace TredersToDoListApp.Infrastructure.Handlers;

public class UpdateTaskCommandHandler : BaseHandler, IRequestHandler<UpdateTaskCommand, string>
{
    public async Task<string> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskToUpdate = _taskcollection.FindById(request.Id);

        if (taskToUpdate is null)
            throw new KeyNotFoundException($"Task with ID {request.Id} not found.");
        if (request.Status is null)
            throw new ArgumentNullException($"Task with ID {request.Id} can not be null");

        taskToUpdate.Status = request.Status;
        _taskcollection.Update(taskToUpdate);

        return taskToUpdate.Status;
    }
}
