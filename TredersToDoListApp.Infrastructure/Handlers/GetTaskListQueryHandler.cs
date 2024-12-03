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
    public async Task<List<TaskTODO>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
    {
        var chuj = new TaskTODO
        {
            Name = "NANANAA",
            Description = "CHUJA",
            Status = "askooksakoas",
        };

        _taskcollection.Insert(chuj);
        var listChuj = new List<TaskTODO>();
        var gowno = _taskcollection.FindAll().ToList();

        foreach (var item in gowno)
        {
            listChuj.Add(item);
        }

        return listChuj;
    }
}
