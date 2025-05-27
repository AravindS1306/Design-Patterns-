sealed class Singleton //sealed classes can be instantiated but can't be inherited
{
    private Singleton() {} //to avoid instantiation from external class

    private static readonly Singleton _instance = new Singleton();

    //If this class can be instantiated outside by removing private constructor, then please
    //use Lazy initialization, so that the instance will be used when needed and not instantiated.
    //Please refer more to Lazy and Eager Initialization.
    //private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());
    //private static Singleton Instance => _instance.Value

    public static Singleton Instance => _instance;

    public void DoSomething()
    {
        Console.WriteLine("Execution during Singleton.");
    }
}

public static void  Main(String[] args)
{
    Console.WriteLine("Starting the program.");
    Console.WriteLine("Execution before Singleton.");
    Singleton.Instance.DoSomething();
    Console.WriteLine("Execution after Singleton.");
}

// Singleton pattern is uses
// Configuration Managers, Logging, Caching, Database Connections(careful)
// Basically this is used in a case where we need to manage things centrally.
