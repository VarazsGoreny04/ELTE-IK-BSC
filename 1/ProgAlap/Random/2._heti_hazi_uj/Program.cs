namespace _2._heti_hazi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ElsoFeladat();
            MasodikFeladat();
        }
        static void ElsoFeladat()
        {
            double a = 0, b = 0;
            bool aHiba, bHiba, Hiba = false;
            do
            {
                if (Hiba)
                    Console.WriteLine("Nem megfelelő karaktertípus!\n");
                Console.WriteLine("Adott az ax + b = 0 függvény.\nAdd meg az A - t és a B - t:");
                aHiba = !double.TryParse(Console.ReadLine(), out a);
                bHiba = !double.TryParse(Console.ReadLine(), out b);
                Hiba = aHiba || bHiba;

            } while (Hiba);
            if (a!=0 && b!=0)
                Console.WriteLine($"x = {Math.Round((-b) / a, 4)}");
            else if (a==0 && b==0)
                Console.WriteLine("x = 0");
            else
                Console.WriteLine("Nincs megoldás!");
        }
        static void MasodikFeladat()
        {
            Random rnd = new Random();
            int tipp, random = rnd.Next(1, 101);
            bool Hiba = false;
            Console.WriteLine($"\nGondoltam egy számra.\nPróbáld meg kitalálni! Tippelj egy számot 1 és 100 között!({random})");
            do
            {
                Hiba = !int.TryParse(Console.ReadLine(), out tipp);
                if (Hiba && !(tipp >= 1 && tipp <= 100))
                {
                    Hiba = true;
                    Console.WriteLine("A szám a tartományon kivül esett!");
                }
            } while (Hiba || tipp != random);
            Console.WriteLine("Nyertél!");
        }
    }
}