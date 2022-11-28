using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class Project
{
    public Project(
        string id,
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

    public Project(
        string name,
        string description,
        string creatorId) : this()
    {
        Name = name;
        Description = description;
        CreatorId = creatorId;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Project()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        Id = Guid.NewGuid().ToString();
        CreationDate = DateTime.Now;
    }

    public string Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreationDate { get; }
    public string? CreatorId { get; }
    public ReadMyUser? Creator { get; }
    public List<ReadMyUser> Participants { get; } = new List<ReadMyUser>();
    public List<Taskunit> Tasks { get; } = new List<Taskunit>();

    public void Modify(string name, string description) 
    {
        Name = name;
        Description = description;
    }

    public void PutParticipantOnProject(ReadMyUser participant) 
    {
        if(!Participants.Any(x => x.Id == participant.Id)) 
        {
            Participants.Add(participant);
        }  
    }
    
    public void TakeParticipantOffProject(string participantId) 
    {
        var participant = Participants.SingleOrDefault(x => x.Id == participantId);
        
        if(participant != null) 
        {
            Participants.Remove(participant);
        }  
    }

}
