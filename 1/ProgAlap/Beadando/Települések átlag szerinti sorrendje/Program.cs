/*
  Készítette: Trefiman Viktor Ádám
  Neptun: DVZCBT
  E-mail: dvzcbt@inf.elte.hu
  Feladat: Települések átlag szerinti sorrendje
*/

using System;
using System.Collections.Generic;

namespace Települések_átlag_szerinti_sorrendje
{
    internal class Program
    {
        struct DataWithIndex
        {
            public int index;
            public int avg;
        }
        static void Main()
        {
            // Mátrix és méretei:
            int n = 0, m = 0;
            int[,] villages = null;

            // Input formájának eldöntése:
            if (Console.IsInputRedirected)
                Input_Biro(ref n, ref m, ref villages);
            else
                Input_Console(ref n, ref m, ref villages);

            // A feladat:
            DataWithIndex[] avgs = new DataWithIndex[n]; 
            Calculate(villages, n, m, ref avgs);

            // Kiírás:
            Output(avgs, n);
        }
        static void Input_Biro(ref int n, ref int m, ref int[,] villages)
        {
            // Méretek bekérése:
            string[] part = Console.ReadLine().Split();
            n = int.Parse(part[0]);
            m = int.Parse(part[1]);

            // Mátrix feltöltése:
            villages = new int[n, m];
            for (int i = 0; i < n; ++i)
            {
                part = Console.ReadLine().Split();
                for (int j = 0; j < m; ++j)
                {
                    villages[i, j] = int.Parse(part[j]);
                }
            }
        }
        static void DataChecker(string ask, ref int data, int min, int max)
        {
            // Adatot kér be és leellenőrzi hogy megfelel-e az intevallumnak:
            do
            {
                Console.ResetColor();
                Console.Write(ask);
                if (int.TryParse(Console.ReadLine(), out data) && data >= min && data <= max)
                    return;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Nem megfelelő adat! [{min};{max}]");
                }
            } while (true);
        }
        static void Input_Console(ref int n, ref int m, ref int[,] villages)
        {
            // Méretek bekérése:
            DataChecker("Települések száma = ", ref n, 1, 1000);
            DataChecker("Napok száma = ", ref m, 1, 1000);

            // Mátrix feltöltése:
            villages = new int[n, m];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                    DataChecker($"{i + 1}. település {j + 1}. nap = ", ref villages[i, j], -50, 50);
            }
        }
        static void Calculate(int[,] villages, int n, int m, ref DataWithIndex[] avgs)
        {
            // Hőmérsékletek összegzése településenként:
            for (int i = 0; i < n; ++i)
            {
                int sum = 0;
                for (int j = 0; j < m; ++j)
                    sum += villages[i, j];
                avgs[i] = new DataWithIndex { index = i + 1, avg = sum };
            }

            // Javított buborék-rendezés az összegekre:
            DataWithIndex temp;
            int k = n - 1, cut;
            while (k > 0)
            {
                cut = 0;
                for (int l = 0; l < k; ++l)
                {
                    if (avgs[l].avg < avgs[l + 1].avg)
                    {
                        temp = avgs[l];
                        avgs[l] = avgs[l + 1];
                        avgs[l + 1] = temp;
                        cut = l;
                    }
                }
                k = cut;
            }
        }
        static void Output(DataWithIndex[] avgs, int n)
        {
            // Az adatok típusának kiírása átláthatóság kedvéért konzolos beolvasásnál:
            if (!Console.IsInputRedirected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Az átlagok szerint rendezett települések sorszámai:");
                Console.ResetColor();
            }

            // Kiírja a rendezett párokból álló tömb index értékeit:
            for (int i = 0; i < n; ++i)
                Console.Write($"{avgs[i].index} ");
        }
    }
}