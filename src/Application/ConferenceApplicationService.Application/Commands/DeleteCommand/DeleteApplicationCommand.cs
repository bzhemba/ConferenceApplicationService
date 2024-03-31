using MediatR;

namespace ConferenceApplicationService.Application.Commands.DeleteCommand;

public class DeleteApplicationCommand : IRequest
{
    public DeleteApplicationCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; }
}