using IdentityModel;

using Microsoft.AspNetCore.Http;

namespace Common.Authorization
{
    public interface ICurrentUserService
    {
        public CurrentUser User { get; }
    }

    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private CurrentUser? _user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private CurrentUser GetUserFromHttpContext()
            => new(
                _httpContextAccessor.HttpContext?.User?.FindFirst(JwtClaimTypes.Id)?.Value ?? "Nem található",
                _httpContextAccessor.HttpContext?.User?.FindFirst(JwtClaimTypes.Name)?.Value ?? "Nem található",
                _httpContextAccessor.HttpContext?.User?.FindFirst(ReadMyClaims.FullName)?.Value ?? "Nem található",
                _httpContextAccessor.HttpContext?.User?.FindFirst(JwtClaimTypes.Role)?.Value ?? "Nem található"
                );

        public CurrentUser User { get => _httpContextAccessor.HttpContext?.User == null ? _user! : GetUserFromHttpContext(); private set => _user = value; }
    }
}
