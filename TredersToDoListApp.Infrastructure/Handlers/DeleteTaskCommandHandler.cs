using MediatR;
using TredersToDoListApp.Application.Commands;

namespace TredersToDoListApp.Infrastructure.Handlers;

public sealed class DeleteTaskCommandHandler : BaseHandler, IRequestHandler<DeleteTaskCommand, string>
{
    public async Task<string> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var result = _taskcollection.FindById(request.Id);

        if (result is null)
            throw new KeyNotFoundException();

        _taskcollection.Delete(result.Id);

        return "true";
    }
}
