namespace _2._heti_hazi
{
    internal class Jegyzet
    {
        /*Külön függvényekbe csináltam meg a feladatrészeket az átláthatóság érdekében,
                    de ezt még nem vettük órán, így nem kell tudnod*/
        static void Main(string[] args)
        {
            ElsoFeladat();          //Itt hívom meg az első,
            MasodikFeladat();       //És itt a második függvényt
        }


        //Az első feladat itt kezdődik:
        static void ElsoFeladat()
        {
            //Szükséges változók:
            double a = 0, b = 0;
            bool aHiba, bHiba, Hiba = false;
            //Hibakeresés:
            do
            {
                if (Hiba)
                    Console.WriteLine("Nem megfelelő karaktertípus!\n");
                Console.WriteLine("Adott az ax + b = 0 függvény.\nAdd meg az A - t és a B - t:");
                aHiba = !double.TryParse(Console.ReadLine(), out a);
                bHiba = !double.TryParse(Console.ReadLine(), out b);
                Hiba = aHiba || bHiba;

            } while (Hiba);
            //Eredmény kiírása:
            Console.WriteLine($"x = {Math.Round((-b) / a, 4)}");
        }


        //A második feladat kezdete:
        static void MasodikFeladat()
        {
            Random rnd = new Random();    //Random szám generálásához szükséges jóság
            //Szükséges változók:
            bool Hiba = false;
            int tipp, random = rnd.Next(1, 101);
            //Az rnd meghívja a random generálást és legenerálja a következő (.Next) random számot
            /*Ha Visual studio 2022-ben vagy 2019-ben nyitod meg a programot akkor, 
              ha ráviszed az egeredet a színes szövegekre kiírja,
              hogy it csinál és hogy mit vár el a felhasználótól*/
            /*Ez esetben hogy add meg, mi az az érték ami az alsó határt jelöli és benne van a halmazban
              és hogy add meg mi a felső határ ami a halmazon kívül esik*/
            //A két határ az 1 és a 100, tehát az alsó határ az 1, a felső határ pedig a 101 lesz

            Console.WriteLine("\nGondoltam egy számra.\nPróbáld meg kitalálni! Tippelj egy számot 1 és 100 között!");
            //Hibakeresés:
            do
            {
                Hiba = !int.TryParse(Console.ReadLine(), out tipp);
                if (Hiba && !(tipp >= 1 && tipp <= 100))
                {
                    Hiba = true;
                    Console.WriteLine("A szám a tartományon kivül esett!");
                }
            } while (Hiba || tipp != random);
            //Eredmény kiírása:
            Console.WriteLine("Nyertél!");
        }
    }
}