using Application.Models;
using MediatR;

namespace ConferenceApplicationService.Application.Commands.EditCommand;

public class EditApplicationCommand : IRequest
    {
    public Guid Id { get; }
    public string Title { get; }
    public ActivityType Activity { get; }
    public string? Description { get; }
    public string Outline { get; }

    public EditApplicationCommand(Guid id, string title, ActivityType activity, string? description, string outline)
    {
        Id = id;
        Title = title;
        Activity = activity;
        Description = description;
        Outline = outline;
    }
    }