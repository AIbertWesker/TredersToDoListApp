using LiteDB;
using MediatR;
using TredersToDoListApp.Application.Queries;
using TredersToDoListApp.Domain.Models;

namespace TredersToDoListApp.Infrastructure.Handlers;

public sealed class GetTaskListQueryHandler : BaseHandler, IRequestHandler<GetTaskListQuery, List<TaskTODO>>
{
    public async Task<List<TaskTODO>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
    {
        var result = _taskcollection.FindAll().ToList();

        return result;
    }
}
