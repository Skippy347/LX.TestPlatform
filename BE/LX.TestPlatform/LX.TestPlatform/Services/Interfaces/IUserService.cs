using LX.TestPlatform.DTO.User;
using LX.TestPlatform.Entities;

namespace LX.TestPlatform.Services.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(CreateUserDto userDto);
    Task<User?> GetUserByIdAsync(Guid id);
    Task<List<User>> GetAllUsersAsync();
    ValueTask DeleteUserAsync(Guid id);
}