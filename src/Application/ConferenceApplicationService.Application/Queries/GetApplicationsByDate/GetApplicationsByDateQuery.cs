using MediatR;

namespace ConferenceApplicationService.Application.Queries.GetApplicationsByDate;

public class GetApplicationsByDateQuery : IRequest<ApplicationsListVm>
{
    public DateTime Date { get; }

    public GetApplicationsByDateQuery(DateTime date)
    {
        Date = date;
    }
}