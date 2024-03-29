using MediatR;

namespace ConferenceApplicationService.Application.Commands.SendCommand;

public class SendApplicationCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}