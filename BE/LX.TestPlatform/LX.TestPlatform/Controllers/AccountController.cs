using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LX.TestPlatform.DTO.Account;
using LX.TestPlatform.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LX.TestPlatform.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationUserDto registrationUserDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _accountService.Registration(registrationUserDto);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response));

                    return Ok();
                }

                return BadRequest(ModelState);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _accountService.Login(loginUserDto);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response));

                    return Ok();
                }

                return BadRequest(ModelState);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[Authorize]
        [HttpPost("profile")]
        public async Task<IActionResult> GetMyData()
        {
            try
            {
                var userEmail = User.Identity.Name;
                var user = await _accountService.GetUserByEmail(userEmail);

                return Ok(user.Email);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}