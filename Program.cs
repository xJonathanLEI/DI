using System;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        /*
         * Register services here so that the final output shows `True`
         */

        /* ***************************************** */

        var serviceProvider = services.BuildServiceProvider();
        var interfaceA = serviceProvider.GetRequiredService<IMyInterfaceA>();
        var interfaceB = serviceProvider.GetRequiredService<IMyInterfaceB>();

        Console.WriteLine($"Is the same instance: {interfaceA.Id == interfaceB.Id}");
    }
}

public interface IMyInterfaceA
{
    int Id { get; }
}
public interface IMyInterfaceB
{
    int Id { get; }
}

public class MyClass : IMyInterfaceA, IMyInterfaceB
{
    public int Id { get; }

    private static readonly Random rnd = new Random();

    public MyClass()
    {
        Id = rnd.Next();
    }
}
