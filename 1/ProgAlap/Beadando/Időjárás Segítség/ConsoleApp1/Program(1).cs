namespace házi3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Deklaráció
            const int MaxN = 101;
            int N, Fnapok;
            int[] Napokmin = new int[MaxN];
            int[] Napokmax = new int[MaxN];
            bool hiba, hibamin, hibamax;
            //Beolvasás ellenőrzése
            //Jól működő, szép megoldás
            do
            {
                Console.WriteLine("Kérem adja meg a vizsgált napok számát:");
                hiba= !int.TryParse(Console.ReadLine(), out N) || N<0;
                if (hiba) { Console.WriteLine("Hibás értéket adott meg! Kérem Próbálja újra!"); }
            }
            while (hiba);
            //Tömbök beolvasása ellenőrzéssel
            /*Itt inkább while ciklust használnék (vagy hibás adatnál kivonnák egyet az i-ből) mivel,
              ha hibás adatot adsz meg, akkor is kilép a ciklusból egy idő után*/
            //(Meg estleg megvizsgálnám hogy a minimum tényleg kisebb a maximum hőmérssékletnél, de ez elhagyható)
            for (int i = 0; i < N; i++)
            {
                
                Console.WriteLine($"Kérem adja meg a(z) {i + 1}. napon mi a legkisebb várható hőmérséklet:");
                hibamin = !int.TryParse(Console.ReadLine(), out Napokmin[i]);
                if (hibamin) { Console.WriteLine("Hibás értéket adott meg! Kérem Próbálja újra!"); }
                Console.WriteLine($"Kérem adja meg a(z) {i + 1}. napon mi a legnagyobb várható hőmérséklet:");
                hibamax = !int.TryParse(Console.ReadLine(), out Napokmax[i]) || Napokmax[i] < Napokmin[i];
                if (hibamax) { Console.WriteLine("Hibás értéket adott meg! Kérem Próbálja újra!"); }
             
            }
            //lényegi feladat
            //Elegáns, tömör megoldás
            Fnapok = 0;
            for (int i = 0; i < N; i++)
            {
                if (Napokmin[i] <=0)
                {
                    Fnapok++;
                }
            }
            Console.WriteLine($"{Fnapok} napon volt fagyos az idő.");
        }
    }
}