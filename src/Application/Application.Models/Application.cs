﻿namespace Application.Models;

public class Application
{
    public Application(Guid id, Guid userId, ActivityType activity, string title, string? description, string plan)
    {
        Id = id;
        UserId = userId;
        Activity = activity;
        Title = title;
        Description = description;
        Plan = plan;
        Status = new ApplicationStatus(false);
        Date = DateTime.Now;
    }

    public Guid Id { get; }
    public Guid UserId { get; }
    public ActivityType Activity { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public string Plan { get; private set; }
    public ApplicationStatus Status { get; private set; }
    public DateTime Date { get; }
    public void ChangeDescription(string newDescription)
    {
        Description = newDescription;
    }
    public void ChangeTitle(string newTitle)
    {
        Title = newTitle;
    }
    public void ChangePlan(string newPlan)
    {
        Plan = newPlan;
    }

    public void ChangeActivity(ActivityType newActivity)
    {
        Activity = newActivity;
    }

    public void ChangeStatus()
    {
        Status = new ApplicationStatus(true);
    }
}