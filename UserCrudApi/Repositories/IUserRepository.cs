using UserCrudApi.Models;

namespace UserCrudApi.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User> CreateUser(User user);
}