using System;
namespace Legtobb_hegycsucs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //első sor bemenet
            int felMag;
            int csucsSor;

            string[] be = Console.ReadLine().Split(" ");
            felMag = int.Parse(be[0]);
            csucsSor = int.Parse(be[1]);

            //második sor tömbbemenet
            int[] magMer = new int[felMag];

            string[] be2 = Console.ReadLine().Split(" ");
            for (int i = 0; i < felMag; i++)
            {
                magMer[i] = int.Parse(be2[i]);
            }

            //csúcsok helyének beazonosítása
            int[] csucsHely = new int[felMag];

            for (int i = 0; i < felMag; i++)
            {
                if ((i != 0) && (i != felMag - 1))
                {
                    if ((magMer[i] > magMer[i - 1]) && (magMer[i] > magMer[i + 1]))
                    {
                        csucsHely[i] = i;
                    }
                }
            }

            //csúcsok helyének eltárolása
            int[] csucsIndVaz = new int[felMag];
            int val = 0;

            for (int i = 0; i < felMag; i++)
            {
                if (csucsHely[i] != 0)
                {
                    csucsIndVaz[val] = csucsHely[i];
                    val++;
                }
            }

            //eltárolás nullák nélkül
            int[] csucsInd = new int[val];

            for (int i = 0; i < val; i++)
            {
                csucsInd[i] = csucsIndVaz[i];
            }

            //köztes csúcsok megszámolása
            int[] csucsSzam = new int[val];
            int val2;

            for (int i = 0; i < val; i++)
            {
                val2 = 0;
                while ((i != (val - val2)) && ((csucsInd[i + val2] - csucsInd[i]) < csucsSor))
                {
                    csucsSzam[i]++;
                    val2++;
                }
                csucsSzam[i]--;
            }
        
            //legtöbb köztes csúcs megkeresése
            int maxCsucs = 0;
            int maxInd = -1;
            int maxInd2 = -1;

            for (int i = 0; i < val; i++)
            {
                if (csucsSzam[i] > maxCsucs)
                {
                    maxCsucs = csucsSzam[i];
                    maxInd = (csucsInd[i] + 1);
                    maxInd2 = (csucsInd[i + maxCsucs] + 1);
                }
            }

            //kimenet
            Console.WriteLine($"{maxInd} {maxInd2}");
        }
    }
}

//ellenőrző kiiratás
/*
Console.WriteLine("\n");
foreach (var elem in csucsHely)
{
    Console.WriteLine(elem);
}
Console.WriteLine("\n");
foreach (var elem in csucsInd)
{
    Console.WriteLine(elem);
}
Console.WriteLine("\n");
foreach (var elem in csucsSzam)
{
    Console.WriteLine(elem);
}
*/

//tesztesetek
/*
20 5
1 1 5 4 3 5 3 5 1 1 1 1 2 1 2 1 2 1 1 1
->
13 17

20 2
1 1 5 4 3 5 3 5 1 1 1 1 2 1 2 1 2 1 1 1
->
-1 -1

20 20
1 1 5 4 3 5 3 5 1 1 1 1 2 1 2 1 2 1 1 1
->
3 17
*/