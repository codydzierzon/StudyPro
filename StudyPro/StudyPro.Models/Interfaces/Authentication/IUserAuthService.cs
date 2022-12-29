using StudyPro.Models.DTO;

namespace StudyPro.Models.Interfaces.Authentication;

public interface IUserAuthService
{
    Task SignIn(User user);
    Task SignOut();
}