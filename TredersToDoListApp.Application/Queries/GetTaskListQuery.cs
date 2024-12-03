using MediatR;
using TredersToDoListApp.Domain.Models;

namespace TredersToDoListApp.Application.Queries;

public class GetTaskListQuery : IRequest<List<TaskTODO>>
{
}
