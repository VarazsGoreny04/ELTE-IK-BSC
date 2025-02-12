using System;
using System.Collections.Generic;
using System.Collections;
namespace Leghosszabb_intervallumban_nem_orzott_3.beadando
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> leiras = new List<string>();
            Console.Error.WriteLine("Orhelyek szama:");
            int orszam = Convert.ToInt32(Console.ReadLine());
            int max = 0;
            int szamlalo = 0;
            for (int i = 0; i < orszam; i++)
            {
                leiras.Add(Console.ReadLine());
            }
            for (int i = 1; i < leiras.Count-1; i++)
            {
                if (leiras[i] == "0")
                {
                    szamlalo++;
                    if (leiras[i - 1] == "1" || leiras[i + 1] == "1")
                    {
                        szamlalo--;
                        if (max < szamlalo)
                        {
                            max = szamlalo;
                            szamlalo = 0;
                        }
                    }
                    if (leiras[i - 1] == "1" && leiras[i + 1] == "1")
                    {
                        szamlalo = szamlalo - 1;
                        if (max < szamlalo)
                        {
                            max = szamlalo;
                            szamlalo = 0;
                        }
                    }
                    if (max < szamlalo)
                        max = szamlalo;
                }
            }
            Console.Write($"{max}");
        }
    }
}