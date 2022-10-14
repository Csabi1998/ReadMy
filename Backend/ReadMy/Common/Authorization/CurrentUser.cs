namespace Common.Authorization
{
    public class CurrentUser
    {
        public CurrentUser(string? userId, string? userName, string? fullName, string? role)
        {
            UserId = userId;
            UserName = userName;
            FullName = fullName;
            Role = role;
        }

        public string? UserId { get; }
        public string? UserName { get; }
        public string? FullName { get; }
        public string? Role { get; }
    }
}
