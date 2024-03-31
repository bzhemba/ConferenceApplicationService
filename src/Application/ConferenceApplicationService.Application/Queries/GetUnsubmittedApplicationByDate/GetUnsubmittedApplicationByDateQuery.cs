using ConferenceApplicationService.Application.Queries.GetApplicationsByDate;
using MediatR;

namespace ConferenceApplicationService.Application.Queries.GetUnsubmittedApplicationByDate;

public class GetUnsubmittedApplicationByDateQuery : IRequest<ApplicationsListVm>
{
    public DateTime Date { get; }

    public GetUnsubmittedApplicationByDateQuery(DateTime date)
    {
        Date = date;
    }
}