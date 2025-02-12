using System;
using System.Collections.Generic;

namespace Legmesszebbi_település_Kukutyintól
{
    internal class Program
    {
        //Adatok tárolása:
        struct Adatok
        {
            public int KukutyinTav, PiripocsTav;
        }
        static List<Adatok> tavolsagok = new List<Adatok>();
        static int Main(string[] args)
        {
            /*
            int hossz = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < hossz; i++)
            {
                string sor = Console.ReadLine();
                string[] darabok = sor.Split();
                Adatok i1 = new Adatok
                {
                    KukutyinTav = Convert.ToInt32(darabok[0]),
                    PiripocsTav = Convert.ToInt32(darabok[1])
                };
                tavolsagok.Add(i1);
            }
            */

            /*
            //Fájl beolvasása:
            StreamReader sr = new StreamReader("../../../be1.txt");
            string sor = "";
            sr.ReadLine();
            while ((sor = sr.ReadLine()) != null)
            {
                string[] darabok = sor.Split();
                Adatok i1 = new Adatok
                {
                    KukutyinTav = Convert.ToInt32(darabok[0]),
                    PiripocsTav = Convert.ToInt32(darabok[1])
                };
                tavolsagok.Add(i1);
            }
            sr.Close();
            */


            ///*
            //Adatbekérés és hibaellenőrzés:
            bool HibaHossz = false;
            Console.Error.WriteLine("Adja meg a lejegyzett távolságok számát! (1<=N<=100)");
            do
            {
                HibaHossz = !int.TryParse(Console.ReadLine(), out int sorHossz);
                if (sorHossz < 1 || sorHossz > 100)
                    HibaHossz = true;
                if (!HibaHossz)
                {
                    Console.Error.WriteLine("Adja meg a távolságokat Kukutyintól és Piripócstól a következő formátumban: ({0<=K<=300} {0<=P<=300})");
                    int i = 0;
                    while (i < sorHossz)
                    {
                        string sor = Console.ReadLine();
                        if (sor.Contains(' '))
                        {
                            string[] darabok = sor.Split(' ');
                            int Kukutyin, Piripocs;
                            bool HibaMin = int.TryParse((darabok[0]), out Kukutyin), HibaMax = int.TryParse((darabok[1]), out Piripocs);
                            if (HibaMax && HibaMin && darabok.Length == 2 && Kukutyin >= 0 && Kukutyin <= 300 && Piripocs >= 0 && Piripocs <= 300)
                            {
                                Adatok i1 = new Adatok
                                {
                                    KukutyinTav = Kukutyin,
                                    PiripocsTav = Piripocs
                                };
                                tavolsagok.Add(i1);
                                i++;
                            }
                            else if (HibaMax && HibaMin && darabok.Length == 2 && !(Kukutyin >= 0 && Kukutyin <= 300 && Piripocs >= 0 && Piripocs <= 300))
                                Console.Error.WriteLine("Az beadott adat az adattartományon kívül esett! ({1<=K<=300} {1<=P<=300})");
                            else if (HibaMax && HibaMin && darabok.Length != 2)
                                Console.Error.WriteLine("Nem megfelelő hosszúságú karakterlánc! ({1<=K<=300} {1<=P<=300})");
                            else
                                Console.Error.WriteLine("Nem megfelelő karaktertípus! ({1<=K<=300} {1<=P<=300})");
                        }
                        else
                            Console.Error.WriteLine("Nem megfelelő hosszúságú karakterlánc! ({1<=K<=300} {1<=P<=300})");
                    }
                }
                else
                    Console.Error.WriteLine("Nem megfelelő karaktertípus! (1<=N<=100)");
            } while (HibaHossz);
            //*/


            //Feladat:
            int max = 0, maxHely = 0;
            for (int i = 0; i < tavolsagok.Count; i++)
            {
                if (tavolsagok[i].KukutyinTav > max)
                {
                    max = tavolsagok[i].KukutyinTav;
                    maxHely = i + 1;
                }
            }
            Console.WriteLine(maxHely);
            return 0;
        }
    }
}