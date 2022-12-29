using StudyPro.Models.Authentication;
using StudyPro.Models.DTO;
using StudyPro.Models.Interfaces.Cryptography;
using StudyPro.Models.Interfaces.Data;
using StudyPro.Services.Data.EF;

namespace StudyPro.Services.Data;

public class EFUserService: IUserService
{
    private readonly StudyProDataContext _db;
    private readonly IHasher _hasher;

    public EFUserService(IHasher hasher, StudyProDataContext db)
    {
        this._hasher = hasher;
        this._db = db;
    }

    public User Register(Registration registration)
    {
        var salt = _hasher.Salt;
        var hashedPassword = _hasher.Hash(registration.Password, salt);

        var user = new User
                   {
                       UserName = registration.UserName,
                       HashedPassword = hashedPassword,
                       Salt = salt
                   };

        _db.Users.Add(user);
        _db.SaveChanges();

        return user;
    }

    public User ValidateUser(Login login)
    {
        if (login.UserName == null || login.Password == null)
            return null;

        var user = _db.Users.FirstOrDefault(u => u.UserName.ToLower() == login.UserName.ToLower());
        if (user == null)
            return null;

        var hashedPassword = _hasher.Hash(login.Password, user.Salt);
        if (!hashedPassword.Equals(user.HashedPassword))
            return null;

        return new User { UserId = user.UserId, UserName = user.UserName };
    }

    public List<User> GetAll()
    {
        return _db.Users.ToList();
    }
    public List<User> Search(string name)
    {
        var users = from u in _db.Users
                    where u.UserName.Contains(name)
                    select u;

        return users.ToList();
    }

    public User GetById(int id)
    {
        return _db.Users.Find(id);
    }

    
}