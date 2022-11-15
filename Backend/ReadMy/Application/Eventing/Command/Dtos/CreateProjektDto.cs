namespace Application.Eventing.Command.Dtos
{
    public class CreateProjektDto
    {
        public CreateProjektDto(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
    }
}
