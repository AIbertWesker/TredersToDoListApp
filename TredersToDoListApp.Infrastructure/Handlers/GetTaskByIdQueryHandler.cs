using MediatR;
using TredersToDoListApp.Application.Queries;
using TredersToDoListApp.Domain.Models;

namespace TredersToDoListApp.Infrastructure.Handlers;

public sealed class GetTaskByIdQueryHandler : BaseHandler, IRequestHandler<GetTaskByIdQuery, TaskTODO>
{
    public async Task<TaskTODO> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var result = _taskcollection.FindById(request.Id);

        if (result != null)
            return result;

        throw new InvalidOperationException($"Task with ID {request.Id} not found.");
    }
}
