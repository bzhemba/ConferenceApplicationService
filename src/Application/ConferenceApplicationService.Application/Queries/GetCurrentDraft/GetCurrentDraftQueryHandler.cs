using Application.Contracts;
using AutoMapper;
using ConferenceApplicationService.Application.Exceptions;
using ConferenceApplicationService.Application.Queries.GetApplicationById;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApplicationService.Application.Queries.GetCurrentDraft;

public class GetCurrentDraftQueryHandler
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetCurrentDraftQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _applicationDbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<ApplicationInformationVm> Handle(GetCurrentDraftQuery request,
        CancellationToken cancellationToken)
    {
        var application = await _applicationDbContext.Applications.FirstOrDefaultAsync(application =>
            (application.UserId == request.UserId) && (application.Status.WasSent == false), cancellationToken);
        if (application == null)
        {
            throw new NotFoundException(nameof(Application), request.UserId);
        }

        return _mapper.Map<ApplicationInformationVm>(application);
    }
}