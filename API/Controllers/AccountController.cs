

using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    
    private readonly SignInManager<User> _signInManager;

    public AccountController(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }


    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterDto registerDto)
    {
        var user = new User
        {
            UserName = registerDto.Email,
            Email = registerDto.Email,
            DisplayName = registerDto.DisplayName
        };

        var result = await _signInManager.UserManager.CreateAsync(user, registerDto.Password!);

        if(result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);

            return Ok(new UserDto
            {
                Email = user.Email!,
                DisplayName = user.DisplayName!
            });
        }

        foreach(var err in result.Errors)
        {
            ModelState.AddModelError(err.Code, err.Description);
        }

        return ValidationProblem();
    }

    [AllowAnonymous]
    [HttpGet("user-info")]
    public async Task<IActionResult> GetUserInfo()
    {
        if(User.Identity?.IsAuthenticated == false) return Unauthorized();

        var user = await _signInManager.UserManager.GetUserAsync(User);

        if (user is null) return Unauthorized();

        return Ok(new
        {
            user.DisplayName,
            user.Email,
            user.Id,
            user.ImageUrl
        });
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return NoContent();
    }


    [Authorize(Roles = "Admin")]
    [HttpPost("register-admin")]
    public async Task<IActionResult> RegisterAdmin(RegisterDto newAdmin)
    {
        var user = new User
        {
            UserName = newAdmin.Email,
            Email = newAdmin.Email,
            DisplayName = newAdmin.DisplayName
        };

        var result = await _signInManager.UserManager.CreateAsync(user, newAdmin.Password!);
        if(!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        await _signInManager.UserManager.AddToRoleAsync(user, "Admin");
        return Ok(new UserDto
        {
            Email = user.Email!,
            DisplayName = user.DisplayName!
        });

    }
}