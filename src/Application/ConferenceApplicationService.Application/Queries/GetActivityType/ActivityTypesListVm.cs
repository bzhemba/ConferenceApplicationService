namespace ConferenceApplicationService.Application.Queries.GetActivityType;

public class ActivityTypesListVm
{
    private IList<ActivityTypeDto> _activityTypes;

    public ActivityTypesListVm(IList<ActivityTypeDto> activityTypes)
    {
        _activityTypes = activityTypes;
    }
}