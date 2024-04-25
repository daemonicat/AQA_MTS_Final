using QaseTestProject.Models.Enums;

namespace QaseTestProject.Models;

public class User
{
    public UserType UserType { get; set; }
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
}