using System.Globalization;
using Bogus;
using QaseTestProject.Models.API;

namespace QaseTestProject.Fakers;

public sealed class TestCaseFaker : Faker<TestCase>
{
    private readonly int[] _authorId = [216468];
    private readonly string[] _dateTime = [DateTime.Now.ToString(CultureInfo.InvariantCulture)];

    public TestCaseFaker()
    {
        RuleFor(b => b.Title, f => f.Random.AlphaNumeric(10));
        RuleFor(b => b.Description, f => f.Random.Words(5));
        RuleFor(b => b.Severity, f => f.Random.Number(1, 4));
        RuleFor(b => b.Priority, f => f.Random.Number(1, 3));
        RuleFor(b => b.Type, f => f.Random.Number(1, 3));
        RuleFor(b => b.Layer, f => f.Random.Number(1, 3));
        RuleFor(b => b.Behavior, f => f.Random.Number(1, 2));
        RuleFor(b => b.Automation, f => f.Random.Number(1));
        RuleFor(b => b.AuthorId, f => f.PickRandom(_authorId));
        RuleFor(b => b.CreatedAt, f => f.PickRandom(_dateTime));
        RuleFor(b => b.UpdatedAt, f => f.PickRandom(_dateTime));
    }
}