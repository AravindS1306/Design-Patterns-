public class Car
{
    public string Engine { get; set; }
    public int Wheels { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        return $"Car with Engine: {Engine}, Wheels: {Wheels}, Color: {Color}";
    }
}

public interface ICarBuilder
{
    void SetEngine(string engine);
    void SetWheels(int number);
    void SetColor(string color);
    Car GetResult();
}

public class SportsCarBuilder : ICarBuilder
{
    private Car _car = new Car();

    public void SetEngine(string engine)
    {
        _car.Engine = engine;
    }

    public void SetWheels(int number)
    {
        _car.Wheels = number;
    }

    public void SetColor(string color)
    {
        _car.Color = color;
    }

    public Car GetResult()
    {
        return _car;
    }
}

class Program
{
    static void Main()
    {
        ICarBuilder builder = new SportsCarBuilder();
        builder.SetEngine("V8");
        builder.SetWheels(4);
        builder.SetColor("Red");

        Car car = builder.GetResult();

        Console.WriteLine(car);
    }
}
//Builder pattern is used to isolate the logic of assigning values of objects of a class 
//If you have a class A with more properties, dont have the entire logic of assigning the values 
// of class A in a single service class. It violates SRP
// so move the building logic to new builder class. Use this only if your have more class properties.
// If there is only one or two, you can directly assign the values of those fields
 
