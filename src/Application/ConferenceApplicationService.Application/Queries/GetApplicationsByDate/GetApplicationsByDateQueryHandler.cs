using Application.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferenceApplicationService.Application.Exceptions;
using ConferenceApplicationService.Application.Queries.GetApplicationById;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApplicationService.Application.Queries.GetApplicationsByDate;

public class GetApplicationsByDateQueryHandler 
    : IRequestHandler<GetApplicationsByDateQuery, ApplicationsListVm>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetApplicationsByDateQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _applicationDbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<ApplicationsListVm> Handle(GetApplicationsByDateQuery request,
        CancellationToken cancellationToken)
    {
        var applications = await _applicationDbContext.Applications.Where(application =>
                application.Date > request.Date).ProjectTo<ApplicationInformationVm>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ApplicationsListVm(applications);
    }
}