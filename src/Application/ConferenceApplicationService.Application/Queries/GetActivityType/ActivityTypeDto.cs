using Application.Models;
using AutoMapper;
using ConferenceApplicationService.Application.Queries.GetApplicationById;

namespace ConferenceApplicationService.Application.Queries.GetActivityType;

public class ActivityTypeDto
{
    public ActivityType ActivityType { get; }
    public string Description { get; }

    public ActivityTypeDto(ActivityType activityType, string description)
    {
        Description = description;
        ActivityType = activityType;
    }
}