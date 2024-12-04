using LiteDB;
using TredersToDoListApp.Domain.Models;

namespace TredersToDoListApp.Infrastructure.Handlers;
public class BaseHandler
{
    internal readonly LiteDatabase _db;
    internal readonly ILiteCollection<TaskTODO> _taskcollection;
    public BaseHandler()
    {
        _db = new LiteDatabase("Filename=todoapp.db;Connection=shared");
        _taskcollection = _db.GetCollection<TaskTODO>("todos");
    }
}
