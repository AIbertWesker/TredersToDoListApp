using LiteDB;
using MediatR;
using TredersToDoListApp.Application.Queries;
using TredersToDoListApp.Domain.Models;

namespace TredersToDoListApp.Infrastructure.Handlers;
public sealed class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, List<TaskTODO>>
{
    private readonly LiteDatabase _db;
    private readonly ILiteCollection<TaskTODO> _taskcollection;

    public GetTaskListQueryHandler()
    {
        _db = new LiteDatabase("Filename=todoapp.db;Connection=shared");
        _taskcollection = _db.GetCollection<TaskTODO>("todos");
    }
#pragma warning disable CS1998
    public async Task<List<TaskTODO>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
#pragma warning restore CS1998 
    {
        var taskList = new List<TaskTODO>();
        var result = _taskcollection.FindAll().ToList();

        return result;
    }
}
