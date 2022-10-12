﻿namespace Domain.Entities;

public class Taskunit
{
    public Taskunit(string id,
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

    public Taskunit(string serialNumber,
                    string name,
                    string description,
                    string type,
                    string projectId) : base()
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
    public string Name { get; }
    public string Description { get; }
    public DateTime CreationDate { get; }
    public string Type { get; }
    public string ProjectId { get; }
    public Project Project { get; }
    public List<Log> Logs { get; } = new List<Log>();
}
