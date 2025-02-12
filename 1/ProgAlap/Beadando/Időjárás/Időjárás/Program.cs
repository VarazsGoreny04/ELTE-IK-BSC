using System;
using System.Collections.Generic;
namespace List
{
    internal class Program
    {
        //Az adatokat tároló struktúra
        struct Adatok
        {
            public int MinimumHomerseklet, MaximumHomerseklet;
        }
        static List<Adatok> homerseklet = new List<Adatok>();

        static void Main(string[] args)
        {
            Beolvasas();
            Elso();
            Masodik();
            Harmadik();
            Negyedik();
        }

        //Csak bekérem az adatokat és ha hibás a bevitel, akkor jelzem és újra bekérem
        static void Beolvasas()
        {
            bool HibaHossz = false;
            Console.Error.WriteLine("Adja meg a lejegyzett napok számát! (<pozitív egész szám>)");
            do
            {
                HibaHossz = !int.TryParse(Console.ReadLine(), out int sorHossz);
                if (sorHossz <= 0)
                    HibaHossz = true;
                if (!HibaHossz)
                {
                    int i = 0;
                    Console.Error.WriteLine("Adja meg a napok minimum és maximum hőmérsékletét a következő formátumban: {<egész szám> <egész szám>}");
                    while (i < sorHossz)
                    {
                        string sor = Console.ReadLine();
                        if (sor.Contains(' '))
                        {
                            string[] darabok = sor.Split(' ');
                            int min, max;
                            bool HibaMin = int.TryParse((darabok[0]), out min), HibaMax = int.TryParse((darabok[1]), out max);
                            if (HibaMax && HibaMin && darabok.Length == 2)
                            {
                                Adatok i1 = new Adatok
                                {
                                    MinimumHomerseklet = min,
                                    MaximumHomerseklet = max
                                };
                                homerseklet.Add(i1);
                                i++;
                            }
                            else if (darabok.Length != 2)
                                Console.Error.WriteLine("Nem megfelelő hosszúságú karakterlánc! {<egész szám> <egész szám>}");
                            else
                                Console.Error.WriteLine("Nem megfelelő karaktertípus! {<egész szám> <egész szám>}");
                        }
                        else
                            Console.Error.WriteLine("Nem megfelelő karakterlánc! {<egész szám> <egész szám>}");
                    }
                }
                else
                    Console.Error.WriteLine("Nem megfelelő karaktertípus! {<pozitív egész szám>}");
            } while (HibaHossz);
        }

        //Innentől lefelé vannak az egyes feladatok
        static void Elso()
        {
            int dbFagy = 0;
            for (int i = 0; i < homerseklet.Count; i++)
            {
                if (homerseklet[i].MinimumHomerseklet <= 0)
                    dbFagy++;
            }
            Console.WriteLine($"#\n{dbFagy}");
        }
        static void Masodik()
        {
            int maxKulonbseg = 0, sorszamKetto = 0;
            for (int i = 0; i < homerseklet.Count; i++)
            {
                if (maxKulonbseg < homerseklet[i].MaximumHomerseklet - homerseklet[i].MinimumHomerseklet)
                {
                    maxKulonbseg = homerseklet[i].MaximumHomerseklet - homerseklet[i].MinimumHomerseklet;
                    sorszamKetto = i + 1;
                }
            }
            Console.WriteLine($"#\n{sorszamKetto}");
        }
        static void Harmadik()
        {
            int i = 1, sorszamHarom = -1;
            while (i < homerseklet.Count && sorszamHarom == -1)
            {
                if (homerseklet[i].MaximumHomerseklet < homerseklet[i - 1].MinimumHomerseklet)
                    sorszamHarom = i + 1;
                i++;
            }
            Console.WriteLine($"#\n{sorszamHarom}");
        }
        static void Negyedik()
        {
            int dbFagyOlvad = 0;
            for (int i = 0; i < homerseklet.Count; i++)
            {
                if (homerseklet[i].MinimumHomerseklet <= 0 && homerseklet[i].MaximumHomerseklet > 0)
                    dbFagyOlvad++;
            }
            Console.Write($"#\n{dbFagyOlvad} ");
            for (int i = 0; i < homerseklet.Count; i++)
            {
                if (homerseklet[i].MinimumHomerseklet <= 0 && homerseklet[i].MaximumHomerseklet > 0)
                    Console.Write($"{i + 1} ");
            }
        }
    }
}