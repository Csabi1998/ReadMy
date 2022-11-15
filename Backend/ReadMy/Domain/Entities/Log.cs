namespace Domain.Entities;

public class Log
{
    public Log(
        string id,
        double workingHours,
        DateTime creationDate,
        string name,
        string description,
        string type,
        string creatorId,
        ReadMyUser creator,
        string taskId,
        Taskunit task)
    {
        Id = id;
        WorkingHours = workingHours;
        CreationDate = creationDate;
        Name = name;
        Description = description;
        Type = type;
        CreatorId = creatorId;
        Creator = creator;
        TaskId = taskId;
        Task = task;
    }

    public Log(
        double workingHours,
        string name,
        string description,
        string type,
        string creatorId,
        string taskId) : base()
    {
        WorkingHours = workingHours;
        Name = name;
        Description = description;
        Type = type;
        CreatorId = creatorId;
        TaskId = taskId;
    }

    public Log()
    {
        Id = Guid.NewGuid().ToString();
        CreationDate = DateTime.Now;
    }

    public string Id { get; }
    public double WorkingHours { get; private set; }
    public DateTime CreationDate { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Type { get; private set; }
    public string CreatorId { get; }
    public ReadMyUser Creator { get; }
    public string TaskId { get; }
    public Taskunit Task { get; }

    public void Modify(
        double workingHours,
        string name,
        string description,
        string type) 
    {
        WorkingHours = workingHours;
        Name = name;
        Description = description;
        Type = type;
    }
}
