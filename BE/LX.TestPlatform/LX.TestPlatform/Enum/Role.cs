using System.ComponentModel.DataAnnotations;

namespace LX.TestPlatform.Enum;

public enum Role
{
    [Display(Name = "User")] User = 0,
    [Display(Name = "Admin")] Admin = 1,
}