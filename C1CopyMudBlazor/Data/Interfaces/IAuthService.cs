using C1CopyMudBlazor.Data.Models;

namespace C1CopyMudBlazor.Data.Interfaces;

public interface IAuthService
{
    Task Login(LoginRequest loginRequest);
    Task Register(RegisterRequest registerRequest);
    Task Logout();
    Task<CurrentUser> CurrentUserInfo();
}