using LX.TestPlatform.DTO.User;
using LX.TestPlatform.Entities;

namespace LX.TestPlatform.MappingProfiles.UserMappingProfile;

public static class UserDtoMapping
{
    public static User MapCreateUpdateToEntity(this CreateUserDto userDto)
    {
        return userDto == null
            ? null
            : new User
            {
                Email = userDto.Email,
                Password = userDto.Password
            };
    }
}