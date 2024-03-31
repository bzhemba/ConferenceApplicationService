using Application.Models;
using MediatR;

namespace ConferenceApplicationService.Application.Commands.CreateCommand;

public class CreateApplicationCommand : IRequest<Guid>
{
    public Guid UserId { get; }
    public Guid Id { get; }
    public string Title { get; }
    public ActivityType Activity { get; }
    public string? Description { get; }
    public string Outline { get; }

    public CreateApplicationCommand(Guid userId, string title, ActivityType activity, string? description, string outline)
    {
        UserId = userId;
        Title = title;
        Activity = activity;
        Description = description;
        Outline = outline;
    }
}