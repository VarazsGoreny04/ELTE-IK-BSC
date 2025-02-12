double text, degree = 59;
do
{
    Console.WriteLine("Add meg a hőmérsékletet!");
    bool error = double.TryParse(Console.ReadLine(), out text);
    if (error == true)
    {
        degree = text;
        if (degree >= -89 && degree <= 58)
        {
            if (degree > 0)
                Console.WriteLine($"A hőmérséklet fagypont feletti. A hőmérséklet Fahrenheitben: {Math.Round(degree * 1.8 + 32, 2)}");
            else
                Console.WriteLine($"A hőmérséklet fagypont alatti. A hőmérséklet Fahrenheitben: {Math.Round(degree * 1.8 + 32, 2)}");
        }
        else
            Console.WriteLine("A Földön nem mértek még ilyen hőmérsékletet!");
    }
    else
        Console.WriteLine("Nem megfelelő karaktertípus!");
} while (degree < -89 || degree > 58);