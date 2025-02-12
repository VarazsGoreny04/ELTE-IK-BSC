namespace Síknegyedek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Változók
            string szoveg = "";
            double xKoord = 0, yKoord = 0;
            string[] tombKoord = new string[] { };
            bool xHiba = false, yHiba = false, hiba;
            do
            {
                Console.Write("Írja be az x és y koordinátákat pontosvesszővel elválasztva: "); //Adatbekérés
                szoveg = Console.ReadLine();
                if (szoveg.Contains(';'))
                {
                    tombKoord = szoveg.Split(';');
                    if (tombKoord.Length == 2)
                    {
                        xHiba = !double.TryParse(tombKoord[0], out xKoord);                     //Hibák elkerülése
                        yHiba = !double.TryParse(tombKoord[1], out yKoord);
                    }
                }
                hiba = xHiba || yHiba;
            } while (hiba);
            if (xKoord > 0 && yKoord > 0)
                Console.WriteLine("I. síknegyed");
            else if (xKoord < 0 && yKoord > 0)
                Console.WriteLine("II. síknegyed");
            else if (xKoord < 0 && yKoord < 0)
                Console.WriteLine("III. síknegyed");                                            //Kiértékelés
            else if (xKoord > 0 && yKoord < 0)
                Console.WriteLine("IV. síknegyed");
            else if (xKoord == 0 && yKoord == 0)
                Console.WriteLine("Origó");
            else
                Console.WriteLine("Tengely");
        }
    }
}