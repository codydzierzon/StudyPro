namespace StudyPro.Models.Interfaces.Cryptography;

public interface IHasher
{
    string Salt { get; }
    string Hash(string content, string salt);
}