using Application.Models;

namespace ConferenceApplicationService.Application.Queries.GetActivityType;

public class GetActivityTypesHandler
{
    private IList<ActivityTypeDto> _activityTypes = new List<ActivityTypeDto>();
    public async Task<ActivityTypesListVm> Handle(CancellationToken cancellationToken)
    {
        _activityTypes.Insert(0, new ActivityTypeDto(ActivityType.Discussion, "Доклад, 35-45 минут"));
        return new ActivityTypesListVm(_activityTypes);
    }
}