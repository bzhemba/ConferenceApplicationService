using Application.Models;
using MediatR;

namespace ConferenceApplicationService.Application.Commands.CreateCommand;

public class CreateApplicationCommand : IRequest<Guid>
{
    public Guid UserId;
    public Guid Id;
    public string Title;
    public Activity Activity;
    public string? Description;
    public string Outline;
}