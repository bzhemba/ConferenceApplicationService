using MediatR;

namespace ConferenceApplicationService.Application.Commands.DeleteCommand;

public class DeleteApplicationCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}