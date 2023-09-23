using System;
class Lambda
{

    public static void Main()
    {
        Func<string> greet = () => "Hello, World!";
        Console.WriteLine(greet());
    }
}
