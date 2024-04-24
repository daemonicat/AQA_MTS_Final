﻿using QaseTestProject.Models.Enums;

namespace QaseTestProject.Models;

public class User
{
    public UserType UserType { get; set; }
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}