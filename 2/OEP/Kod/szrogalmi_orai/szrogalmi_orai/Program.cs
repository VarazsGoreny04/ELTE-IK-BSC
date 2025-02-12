namespace COVID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Oltohely oh1 = new Oltohely() { hely = "Miskolc" };
            Oltohely oh2 = new Oltohely() { hely = "Budapest" };

            Vakcina v1 = new Astrazeneca();
            Vakcina v2 = new Astrazeneca();
            Vakcina v3 = new Modena();
            Vakcina v4 = new Modena();
            Vakcina v5 = new Pfizer();
            Vakcina v6 = new Pfizer();

            Paciens p1 = new Paciens() { taj = "000000" };
            Paciens p2 = new Paciens() { taj = "000001" };
            Paciens p3 = new Paciens() { taj = "000010" };
            Paciens p4 = new Paciens() { taj = "000011" };

            oh1.Beszerez(v1);
            oh1.Beszerez(v2);
            oh1.Beszerez(v3);

            oh2.Beszerez(v4);
            oh2.Beszerez(v5);
            oh2.Beszerez(v6);

            oh1.Regisztral(p1);
            oh1.Regisztral(p2);
            oh2.Regisztral(p3);
            oh2.Regisztral(p4);

            oh1.Beolt(p1, "astrazeneca");
            oh1.Beolt(p1, "modena");
            oh2.Beolt(p3, "modena");
            oh2.Beolt(p3, "pfizer");

            int a;
            if ((a = oh1.Hanyankettot() + oh2.Hanyankettot()) == 2)
            {
                Console.WriteLine("Sikeresen oldottad meg a feladatot!");
            }
            else
            {
                Console.WriteLine($"{a} : Nem jól oldottad meg a feladatot!") ;
            }
        }
    }
}