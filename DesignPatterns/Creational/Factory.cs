public class A
{
    public void DoSomething()
    {
        Console.WriteLine("From Class A");
    }
}

public class B
{
    public void DoSomething()
    {
        Console.WriteLine("From Class B");
    }
}

public interface IABFactory
{
    void DoSomething();
}

public class ABFactory
{
    private readonly Dictionary<string, Func<IABFactory>> _factory;
    public ABFactory()
    {
        _factory = new Dictionary<string, Func<IABFactory>>
        {
            {"A", () => new A() },
            {"B", () => new B() }
        }
        // This can be done without delegates as well
    }

    public IABFactory CreateFactory(string type)
    {
        if (_factory.TryGetValue(type, out var factory))
        {
            return factory();
        }
    }
}

public static void Main(String[] args)
{
    string type = "A";
    ABFactory factory = new ABFactory();
    factory.CreateFactory("A");
}

// Main use of factory methods is to have a common place for creating objects of a class that has various types
// If your use case has various types of same family like car and bike as Vehicles, directly go with Factory