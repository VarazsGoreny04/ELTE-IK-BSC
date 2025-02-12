namespace factorials
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int f = 1, n, sz = 0;
            bool hiba;
            do
            {
                Console.Write("Adja meg az n értékét: ");
                hiba = !int.TryParse(Console.ReadLine(), out n);
            } while (hiba);
            for (int i = 1; i <= n; i++)
            {
                f *= i;
            }
            Console.WriteLine($"Az {n} faktoriálisa {f}");
            for (int i = 0; i <= n; i++)
            {
                sz += i;
            }
            Console.WriteLine($"1-től {n}-ig a számok szummája {sz}");
        }
    }
}