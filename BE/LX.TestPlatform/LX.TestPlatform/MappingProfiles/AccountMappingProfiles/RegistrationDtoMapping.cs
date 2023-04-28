using LX.TestPlatform.DTO.Account;
using LX.TestPlatform.Entities;
using LX.TestPlatform.Enum;
using LX.TestPlatform.Helpers;

namespace LX.TestPlatform.MappingProfiles.AccountMappingProfiles;

public static class RegistrationDtoMapping
{
    public static User MapCreateUpdateToEntity(this RegistrationUserDto registrationUserDto)
    {
        return registrationUserDto == null
            ? null
            : new User
            {
                Email = registrationUserDto.Email,
                Password = HashPasswordHelper.HashPassword(registrationUserDto.Password),
                Role = Role.User
            };
    }
}