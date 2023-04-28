using LX.TestPlatform.Enum;

namespace LX.TestPlatform.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public Role Role { get; set; }
}