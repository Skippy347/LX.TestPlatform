using LX.TestPlatform.DTO.User;
using LX.TestPlatform.Entities;
using LX.TestPlatform.Interfaces;
using LX.TestPlatform.MappingProfiles.UserMappingProfile;
using LX.TestPlatform.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LX.TestPlatform.Services.Implementation;

public class UserService : IUserService
{
    private readonly IBaseRepository<User> _userRepository;

    public UserService(IBaseRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CreateUserAsync(CreateUpdateUserDto userDto)
    {
        var user = userDto.MapCreateUpdateToEntity();

        await _userRepository.CreateAsync(user);
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAll().ToListAsync();

        return users;
    }

    public async ValueTask DeleteUserAsync(Guid id)
    {
        var foundUser = await _userRepository.GetByIdAsync(id);
        if (foundUser == null)
        {
            throw new ArgumentNullException(nameof(foundUser), "User not found");
        }

        await _userRepository.DeleteAsync(foundUser);
    }
}