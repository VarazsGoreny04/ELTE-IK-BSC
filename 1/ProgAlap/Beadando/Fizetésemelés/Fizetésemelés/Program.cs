using System;
using System.Collections.Generic;
namespace Fizetésemelés
{
    internal class Program
    {
        struct Workers
        {
            public string name;
            public int age;
            public int salary;
        }
        static List<Workers> worker = new List<Workers>();
        struct Changes
        {
            public string name;
            public int age;
            public int salary;
        }
        static List<Changes> change = new List<Changes>();
        static void Main(string[] args)
        {
            int ageNow = 0, salaryNow = 0;
            bool lengthError = false, ageError = false, salaryError = false;
            Console.Error.WriteLine("Add meg egy dolgozó adatait! ({név} {kor} {fizetés})");
            while (lengthError || ageError || salaryError)
            {
                string[] peaces = Console.ReadLine().Split(", ");
                if (peaces.Length != 3)
                    lengthError = true;
                else
                {
                    ageError = int.TryParse(peaces[1], out ageNow);
                    salaryError = int.TryParse(peaces[2], out salaryNow);
                }
                Workers i1 = new Workers()
                {
                    name = peaces[0],
                    age = ageNow,
                    salary = salaryNow
                };
                worker.Add(i1);
            }
            for (int i = 0; i < worker.Count; i++)
            {
                int salaryNew = worker[i].salary;
                if (worker[i].age < 30)
                {
                    salaryNew = worker[i].salary + 50000;
                }
                Changes i1 = new Changes()
                {
                    name = worker[i].name,
                    age = worker[i].age,
                    salary = salaryNew
                };
                change.Add(i1);
            }
        }
    }
}