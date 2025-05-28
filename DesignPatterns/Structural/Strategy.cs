public interface IPaymentStrategy
{
    void Pay(decimal amount);
}

public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} using Credit Card.");
    }
}

public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} using PayPal.");
    }
}

public class CryptoPayment : IPaymentStrategy
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paid {amount:C} using Cryptocurrency.");
    }
}

public class PaymentContext
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        _paymentStrategy = strategy;
    }

    public void PayAmount(decimal amount)
    {
        if (_paymentStrategy == null)
        {
            Console.WriteLine("Payment strategy not set!");
            return;
        }

        _paymentStrategy.Pay(amount);
    }
}

// When to use strategy
// You need different variants of an algorithm (e.g., sorting, payment methods).
// You want to switch logic dynamically at runtime.
// You want to avoid large conditional statements (e.g., if/else or switch).
// Stratey is mostly used with factory