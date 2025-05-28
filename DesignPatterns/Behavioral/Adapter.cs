public interface ITemperatureFahrenheit
{
    double GetTemperatureFahrenheit();
}

public class CelsiusSensor
{
    public double GetTemperatureCelsius()
    {
        return 25.0;
    }
}

public class TemperatureAdapter : ITemperatureFahrenheit
{
    private readonly CelsiusSensor _celsiusSensor;

    public TemperatureAdapter(CelsiusSensor celsiusSensor)
    {
        _celsiusSensor = celsiusSensor;
    }

    public double GetTemperatureFahrenheit()
    {
        double celsius = _celsiusSensor.GetTemperatureCelsius();
        return (celsius * 9 / 5) + 32;
    }
}

class Program
{
    static void Main()
    {
        CelsiusSensor celsiusSensor = new CelsiusSensor();
        ITemperatureFahrenheit fahrenheitTemperature = new TemperatureAdapter(celsiusSensor);

        Console.WriteLine($"Temperature in Fahrenheit: {fahrenheitTemperature.GetTemperatureFahrenheit()} °F");
    }
}

// The Adapter Pattern allows incompatible interfaces to work together. It's often used to make existing classes work with others without modifying their source code.
// Think of a power plug adapter — it allows a device with one plug type to be used with a different socket.
// But this pattern has rare usecases because people are preferring to rewrite the code, instead of using a adapter

