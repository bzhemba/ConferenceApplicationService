using Application.Contracts;
using AutoMapper;
using ConferenceApplicationService.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApplicationService.Application.Queries.GetApplicationById;

public class GetApplicationByIdQueryHandler: IRequestHandler<GetApplicationByIdQuery, 
    ApplicationInformationVm>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetApplicationByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _applicationDbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<ApplicationInformationVm> Handle(GetApplicationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var application = await _applicationDbContext.Applications.FirstOrDefaultAsync(application =>
            application.Id == request.Id, cancellationToken);
        if (application == null)
        {
            throw new NotFoundException(nameof(Application), request.Id);
        }

        return _mapper.Map<ApplicationInformationVm>(application);
    }
    
}