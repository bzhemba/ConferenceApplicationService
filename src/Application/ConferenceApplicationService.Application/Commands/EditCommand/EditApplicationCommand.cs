using Application.Models;
using MediatR;

namespace ConferenceApplicationService.Application.Commands.EditCommand;

public class EditApplicationCommand : IRequest
    {
    public Guid UserId;
    public Guid Id;
    public string Title;
    public ActivityType Activity;
    public string? Description;
    public string Plan;
}