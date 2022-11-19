namespace Application.Eventing.Command.Dtos
{
    public class AddProjektParticipantDto
    {
        public AddProjektParticipantDto(string projektId, string userId)
        {
            ProjektId = projektId;
            UserId = userId;
        }

        public string ProjektId { get; }
        public string UserId { get; }
    }
}
