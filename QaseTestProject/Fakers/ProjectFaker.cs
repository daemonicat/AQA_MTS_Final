using Bogus;
using QaseTestProject.Models.API;

namespace QaseTestProject.Fakers;

public sealed class ProjectFaker : Faker<Project>
{
    private readonly string[] _accessMode = ["all"];
    public ProjectFaker()
    {
        RuleFor(b => b.Title, f => f.Random.AlphaNumeric(6));
        RuleFor(b => b.Code, f => f.Random.String2(8).ToUpper());
        RuleFor(b => b.Description, f => f.Random.Words(5));
        RuleFor(b => b.Access, f => f.PickRandom(_accessMode));
    }
}