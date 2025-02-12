using System;

namespace Rational
{
    class Program
    {
        static void Main()
        {
            try
            {
                Rational a = new (3, -2);
                Rational b = new (-20, 3);

                Console.WriteLine($"a + b = {a + b}");
                Console.WriteLine($"a - b = {a - b}");
                Console.WriteLine($"a * b = {a * b}");
                Console.WriteLine($"a / b = {a / b}");
            }
            catch(Rational.NullDenominator)
            {
                Console.WriteLine("Érvénytelen szám");
            }
            catch (Rational.NullDivision)
            {
                Console.WriteLine("Nullával való osztás");
            }
        }
    }
}
