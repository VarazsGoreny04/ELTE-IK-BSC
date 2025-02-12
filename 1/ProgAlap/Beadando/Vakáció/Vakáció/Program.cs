using System;
using System.Collections.Generic;

namespace Vakáció
{
    internal class Program
    {
        static int[] days = new int[366];
        static void Main(string[] args)
        {
            Input();
            Calculation();
        }
        static void Input()
        {
            //Változók:
            string firstOutput = "Add meg hány napot szeretnél megadni! (minimum 1 és maximum 366)",
                   inputError = "Nem megfelelő a bemenet! Újra!",
                   secondOutput = "Add meg hogy az adott nap vakáció volt-e! (1 = igen, 0 = nem)";
            int numberOfDays = 0, counter = 0;
            bool numberOfDaysError = true, dayTypeError = true;

            //Napok számának bekérése:
            Console.Error.WriteLine(firstOutput);
            while (numberOfDaysError)
            {
                numberOfDaysError = !int.TryParse(Console.ReadLine(), out numberOfDays) || numberOfDays < 1 || numberOfDays > 366;
                if (numberOfDaysError)
                {
                    Console.Clear();
                    Console.Error.WriteLine($"{firstOutput}\n{inputError}");
                }
            }

            //Napok típusának bekérése:
            Console.Clear();
            Console.Error.WriteLine($"{firstOutput}\n{numberOfDays}\n{secondOutput}");
            while (counter < numberOfDays || dayTypeError)
            {
                dayTypeError = !int.TryParse(Console.ReadLine(), out days[counter]) || days[counter] != 0 && days[counter] != 1;
                if (dayTypeError)
                {
                    Console.Clear();
                    Console.Error.WriteLine($"{firstOutput}\n{numberOfDays}\n{secondOutput}");
                    for (int i = 0; i < counter; i++)
                    {
                        Console.Error.WriteLine(days[i]);
                    }
                    Console.Error.WriteLine(inputError);
                }
                else
                    counter++;
            }
        }
        static void Calculation()
        {
            int freedaysInARow = 0, daysUntilNextHoliday = 0;
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i] == 1)
                {
                    freedaysInARow++;
                    if (freedaysInARow == 7)
                    {
                        /*Azért i - 5, mert az eddig vizsgált napok hossza - 1 adná meg az első napot,
                          de az i nulláról indul, szóval csak - 5*/
                        Console.WriteLine(i - 5);
                        break;
                    }
                }
                else
                    freedaysInARow = 0;
            }
        }
    }
}