namespace Application.Eventing.Command.Dtos
{
    public class RegisterDto
    {
        public RegisterDto(string userName, string fullName, string password, string role)
        {
            UserName = userName;
            FullName = fullName;
            Password = password;
            Role = role;
        }

        public string UserName { get; }
        public string FullName { get; }
        public string Password { get; }
        public string Role { get; }
    }
}
