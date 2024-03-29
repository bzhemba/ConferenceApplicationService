using Application.Contracts;
using ConferenceApplicationService.Application.Commands.DeleteCommand;
using ConferenceApplicationService.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApplicationService.Application.Commands.SendCommand;

public class SendApplicationCommandHandler : IRequestHandler<DeleteApplicationCommand>
{
    private readonly IApplicationDbContext _applicationDbContext;
    public SendApplicationCommandHandler(IApplicationDbContext dbContext) => 
        _applicationDbContext = dbContext;
    public async Task<Unit> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
    {
        var application = await _applicationDbContext.Applications.FirstOrDefaultAsync(application =>
            application.Id == request.Id, cancellationToken);
        if (application == null || application.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(Application), request.Id);
        }

        if (application.Status.WasSent)
        {
            throw new EnableToEditOrDeleteException("You can't delete submitted application");
        }

        application.ChangeStatus();
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}