using MediatR;

namespace ConferenceApplicationService.Application.Queries.GetApplicationsByDate;

public class GetApplicationsByDateQuery : IRequest<ApplicationsListVm>
{
    public DateTime Date;
}