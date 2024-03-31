using Application.Contracts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferenceApplicationService.Application.Queries.GetApplicationById;
using ConferenceApplicationService.Application.Queries.GetApplicationsByDate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApplicationService.Application.Queries.GetUnsubmittedApplicationByDate;

public class GetUnsubmittedApplicationByDateQueryHandler 
    : IRequestHandler<GetUnsubmittedApplicationByDateQuery, ApplicationsListVm>
    {
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetUnsubmittedApplicationByDateQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _applicationDbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<ApplicationsListVm> Handle(GetUnsubmittedApplicationByDateQuery request,
        CancellationToken cancellationToken)
    {
        var applications = await _applicationDbContext.Applications.Where(application =>
                (application.Date > request.Date) && (application.WasSentStatus == false))
            .ProjectTo<ApplicationInformationVm>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ApplicationsListVm(applications);
    }
}