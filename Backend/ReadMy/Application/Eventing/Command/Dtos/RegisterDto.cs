namespace Application.Eventing.Command.Dtos
{
    public class RegisterDto
    {
        public RegisterDto(string userName, string fullName, string password)
        {
            UserName = userName;
            FullName = fullName;
            Password = password;
        }

        public string UserName { get; }
        public string FullName { get; }
        public string Password { get; }
    }
}
