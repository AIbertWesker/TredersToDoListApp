using MediatR;
using TredersToDoListApp.Domain.Models;

namespace TredersToDoListApp.Application.Queries;

public class GetTaskByIdQuery : IRequest<TaskTODO>
{
    public int Id { get; set; }
}
