using StudyPro.Models.Authentication;
using StudyPro.Models.DTO;

namespace StudyPro.Models.Interfaces.Data;

public interface IUserService
{
    User? Register(Registration registration);
    User? ValidateUser(Login login);
    List<User> GetAll();
    List<User> Search(string name);
    User? GetById(int id);
}