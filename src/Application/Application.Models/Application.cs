namespace Application.Models;

public class Application
{
    public Application(Guid id, Guid userId, Activity activity, string title, string? description, string outline)
    {
        Id = id;
        UserId = userId;
        Activity = activity;
        Title = title;
        Description = description;
        Outline = outline;
        Status = new ApplicationStatus(false);
        Date = DateTime.Now;
    }

    public Guid Id { get; }
    public Guid UserId { get; }
    public Activity Activity { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public string Outline { get; private set; }
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
        Outline = newPlan;
    }

    public void ChangeActivity(Activity newActivity)
    {
        Activity = newActivity;
    }

    public void ChangeStatus()
    {
        Status = new ApplicationStatus(true);
    }
}