using Microsoft.AspNetCore.Mvc;
using UserCrudApi.DTOs;
using UserCrudApi.Services;

namespace UserCrudApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;

    public AuthController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        try
        {
            var user = await _userService.Register(dto);
            return Ok(new { message = "User registered successfully", userId = user.Id });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _userService.Login(dto);
        if (user == null)
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        return Ok(new { message = "Login successful", user });
    }
}