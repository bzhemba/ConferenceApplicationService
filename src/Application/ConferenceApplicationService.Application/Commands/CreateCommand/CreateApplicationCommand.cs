using Application.Models;
using MediatR;

namespace ConferenceApplicationService.Application.Commands.CreateCommand;

public class CreateApplicationCommand : IRequest<Guid>
{
    public Guid UserId;
    public Guid Id;
    public string Title;
    public ActivityType Activity;
    public string? Description;
    public string Plan;
}