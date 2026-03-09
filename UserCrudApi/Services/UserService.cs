using UserCrudApi.DTOs;
using UserCrudApi.Models;
using UserCrudApi.Repositories;

namespace UserCrudApi.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Register(RegisterDto dto)
    {
        // Check if user exists
        var existingUser = await _userRepository.GetUserByEmail(dto.Email);
        if (existingUser != null)
        {
            throw new Exception("User already exists");
        }

        // Hash password (simple for demo)
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = passwordHash,
            Role = dto.Role,
            CreatedAt = DateTime.UtcNow
        };

        return await _userRepository.CreateUser(user);
    }

    public async Task<User?> Login(LoginDto dto)
    {
        var user = await _userRepository.GetUserByEmail(dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
        {
            return null;
        }

        return user;
    }
}