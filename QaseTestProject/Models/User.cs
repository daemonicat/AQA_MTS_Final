using QaseTestProject.Models.Enums;

namespace QaseTestProject.Models;

public class User
{
    public UserType UserType { get; set; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}