using System.Security.Claims;
using LX.TestPlatform.DTO.Account;
using LX.TestPlatform.Entities;

namespace LX.TestPlatform.Services.Interfaces;

public interface IAccountService
{
    Task<ClaimsIdentity> Registration(RegistrationUserDto registrationUserDto);
    Task<ClaimsIdentity> Login(LoginUserDto loginUserDto);

    Task<User> GetUserByEmail(string Email);
}