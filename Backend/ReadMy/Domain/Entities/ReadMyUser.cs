using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ReadMyUser : IdentityUser
{
    public string FullName { get; set; } = default!;
    public List<Log> Logs { get; set; } = new List<Log>();
    public List<Project> Projects { get; set; } = new List<Project>();
    public List<Project> CreatorProjects { get; set; } = new List<Project>(); 
}
