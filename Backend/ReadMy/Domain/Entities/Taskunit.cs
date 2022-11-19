namespace Domain.Entities;

public class Taskunit
{
    public Taskunit(
        string id,
        string serialNumber,
        string name,
        string description,
        DateTime creationDate,
        string type,
        string projectId,
        Project project,
        List<Log> logs)
    {
        Id = id;
        SerialNumber = serialNumber;
        Name = name;
        Description = description;
        CreationDate = creationDate;
        Type = type;
        ProjectId = projectId;
        Project = project;
        Logs = logs;
    }

    public Taskunit(
        string serialNumber,
        string name,
        string description,
        string type,
        string projectId) : this()
    {
        SerialNumber = serialNumber;
        Name = name;
        Description = description;
        Type = type;
        ProjectId = projectId;
    }

    public Taskunit()
    {
        Id = Guid.NewGuid().ToString();
        CreationDate = DateTime.Now;
    }
    public string Id { get; }
    public string SerialNumber { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreationDate { get; }
    public string Type { get; private set; }
    public string ProjectId { get; }
    public Project Project { get; }
    public List<Log> Logs { get; } = new List<Log>();

    public void Modify(
        string name,
        string description,
        string type) 
    {
        Name = name;
        Description = description;
        Type = type;
    }
}
