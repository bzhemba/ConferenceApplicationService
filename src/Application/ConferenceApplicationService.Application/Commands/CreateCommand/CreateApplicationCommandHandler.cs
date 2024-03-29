using Application.Contracts;
using MediatR;

namespace ConferenceApplicationService.Application.Commands.CreateCommand;

public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, Guid>
{
    private readonly IApplicationDbContext _applicationDbContext;
    public CreateApplicationCommandHandler(IApplicationDbContext dbContext) => 
        _applicationDbContext = dbContext;
    public async Task<Guid> Handle(CreateApplicationCommand request,
        CancellationToken cancellationToken)
    {
        var application = new global::Application.Models.Application(Guid.NewGuid(),
            request.UserId, request.Activity, request.Title, request.Description, request.Plan);
        
        await _applicationDbContext.Applications.AddAsync(application, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        
        return application.Id;
    }
}