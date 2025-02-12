using System;
namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N, ossz = 0, dbEsett = 0;
            bool Hiba = false;
            int[] napok = new int[100];
            Console.Error.WriteLine("Adja meg hány napon mértek csapadékot az utóbbi időben (Maximum 100 adható meg!):");
            do
            {
                Hiba = !int.TryParse(Console.ReadLine(), out N) || N > 100;
                if (Hiba)
                    Console.Error.WriteLine("Nem megfelelő karaktertípus vagy érték!");
            } while (Hiba);

            Console.Error.WriteLine("Add meg hány miliméter csapadék esett az utóbbi nap folyamán naponként (Maximum 1000 adható meg!):");
            for (int i = 0; i < N; i++)
            {
                do
                {
                    Hiba = !int.TryParse(Console.ReadLine(), out napok[i]) || napok[i] < 0 || napok[i] > 1000;
                    if (Hiba)
                    {
                        Console.Error.WriteLine("Nem megfelelő karaktertípus vagy érték!");
                    }
                } while (Hiba);
            }
            Console.Error.WriteLine();

            for (int i = 0; i < N; i++)
            {
                Console.Error.WriteLine($"{i+1}. nap: {napok[i]}mm");
            }

            //A feladat:
            for (int i = 0; i < napok.Length; i++)
            {
                ossz += napok[i];
            }
            Console.Error.WriteLine($"\n\tA(z) {N} nap alatt {ossz}mm csapadék esett");

            //B feladat:
            for (int i = 0; i < napok.Length; i++)
            {
                if (napok[i] > 0)
                    dbEsett++;
            }
            Console.WriteLine(dbEsett);
        }
    }
}