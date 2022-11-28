namespace Application.Eventing.Command.Dtos
{
    public class RemoveProjektParticipantDto
    {
        public RemoveProjektParticipantDto(string projektId, string userId)
        {
            ProjektId = projektId;
            UserId = userId;
        }

        public string ProjektId { get; }
        public string UserId { get; }
    }
}
