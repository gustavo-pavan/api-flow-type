namespace FlowType.Test.Unit.Domain;

public class FlowTest : IDisposable
{
    private readonly Faker _faker = new();
    private dynamic? _dynamic;

    public FlowTest()
    {
        _dynamic = new
        {
            Id = _faker.Random.Guid(),
            Name = _faker.Name.FullName(),
            Description = _faker.Random.AlphaNumeric(400),
            TypeFlow = _faker.Random.Int(1, 2)
        };
    }

    [Fact]
    public void Should_Object_Instance_Is_Equal()
    {
        Flow flow = new(_dynamic?.Id, _dynamic?.Name, _dynamic?.Description, _dynamic?.TypeFlow);
        (_dynamic as object).Should().BeEquivalentTo(flow);
    }

    public void Dispose()
    {
        _dynamic = null;
    }
}

public class Flow
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int TypeFlow { get; private set; }

    public Flow(Guid id, string name, string description, int typeFlow)
    {
        Id = id;
        Name = name;
        Description = description;
        TypeFlow = typeFlow;
    }
}