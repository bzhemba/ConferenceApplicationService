using Application.Contracts;
using ConferenceApplicationService.Application.Commands.CreateCommand;
using ConferenceApplicationService.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApplicationService.Application.Commands.EditCommand;

public class EditApplicationCommandHandler: IRequestHandler<EditApplicationCommand>
{
    private readonly IApplicationDbContext _applicationDbContext;
    public EditApplicationCommandHandler(IApplicationDbContext dbContext) => 
        _applicationDbContext = dbContext;
    public async Task<Unit> Handle(EditApplicationCommand request,
        CancellationToken cancellationToken)
    {
        var application = await _applicationDbContext.Applications.FirstOrDefaultAsync(application =>
            application.Id == request.Id, cancellationToken);
        if (application == null)
        {
            throw new NotFoundException(nameof(Application), request.Id);
        }

        if (application.WasSentStatus)
        {
            throw new EnableToEditOrDeleteException("You can't edit submitted application");
        }

        if (request.Description != null) application.ChangeDescription(request.Description);
        application.ChangeTitle(request.Title);
        application.ChangeActivity(request.Activity);
        application.ChangePlan(request.Outline);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}