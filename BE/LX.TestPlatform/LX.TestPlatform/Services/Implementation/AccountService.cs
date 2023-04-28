using System.Security.Claims;
using LX.TestPlatform.DTO.Account;
using LX.TestPlatform.Entities;
using LX.TestPlatform.Helpers;
using LX.TestPlatform.Interfaces;
using LX.TestPlatform.MappingProfiles.AccountMappingProfiles;
using LX.TestPlatform.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPlatform.Services.Implementation;

public class AccountService : IAccountService
{
    private readonly IBaseRepository<User> _userRepository;

    public AccountService(IBaseRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ClaimsIdentity> Registration(RegistrationUserDto registrationUserDto)
    {
        var userEmail = await _userRepository.GetAll()
            .FirstOrDefaultAsync(userEmail => userEmail.Email == registrationUserDto.Email);
        if (userEmail != null)
        {
            throw new ArgumentException("Email already registered.");
        }

        var user = registrationUserDto.MapCreateUpdateToEntity();

        await _userRepository.CreateAsync(user);

        var result = Authenticate(user);

        return result;
    }

    public async Task<ClaimsIdentity> Login(LoginUserDto loginUserDto)
    {
        var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Email == loginUserDto.Email);
        if (user == null)
        {
            throw new ArgumentException("No user with this email found.");
        }

        var isPasswordValid = HashPasswordHelper.VerifyPassword(loginUserDto.Password, user.Password);
        if (!isPasswordValid)
        {
            throw new ArgumentException("Invalid email or password");
        }

        var result = Authenticate(user);

        return result;
    }

    private ClaimsIdentity Authenticate(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
        };
        return new ClaimsIdentity(claims, "ApplicationCookie",
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
    }
    
    public async Task<User> GetUserByEmail(string email)
    {
        return await _userRepository.GetAll()
            .FirstOrDefaultAsync(user => user.Email == email);
    }

}