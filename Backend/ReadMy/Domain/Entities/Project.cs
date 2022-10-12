using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class Project
{
    public Project(string id,
                   string name,
                   string description,
                   DateTime creationDate,
                   string creatorId,
                   ReadMyUser creator,
                   List<ReadMyUser> participants,
                   List<Taskunit> tasks)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatorId = creatorId;
        Creator = creator;
        Participants = participants;
        Tasks = tasks;
        CreationDate = creationDate;
    }

    public Project(string name,
                   string description,
                   string creatorId) : base()
    {
        Name = name;
        Description = description;
        CreatorId = creatorId;
    }

    public Project()
    {
        Id = Guid.NewGuid().ToString();
        CreationDate = DateTime.Now;
    }

    public string Id { get; }
    public string Name { get; }
    public string Description { get; }
    public DateTime CreationDate { get; }
    public string? CreatorId { get; }
    public ReadMyUser? Creator { get; }
    public List<ReadMyUser>? Participants { get; } = new List<ReadMyUser>();
    public List<Taskunit>? Tasks { get; } = new List<Taskunit>();

}
