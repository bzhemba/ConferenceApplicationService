using MediatR;

namespace ConferenceApplicationService.Application.Commands.SendCommand;

public class SendApplicationCommand : IRequest
{
    public SendApplicationCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}