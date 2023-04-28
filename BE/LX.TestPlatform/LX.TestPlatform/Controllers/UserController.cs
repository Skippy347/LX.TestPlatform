using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LX.TestPlatform.DTO.User;
using LX.TestPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPlatform.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
    {
        await _userService.CreateUserAsync(userDto);

        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        return user != null ? Ok(user) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUser()
    {
        var users = await _userService.GetAllUsersAsync();

        return Ok(users);
    }

    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteUser(Guid id)
    {
        await _userService.DeleteUserAsync(id);

        return NoContent();
    }
}