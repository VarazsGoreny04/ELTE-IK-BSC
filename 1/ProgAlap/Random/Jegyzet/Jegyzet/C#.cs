namespace _2._heti_hazi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Valtozok();
            Static();
            Tombok();
            Listak();
            Strukturak();
            Fuggvenyek();
            Random();
        }
        static void Valtozok()
        {
            //Az egyes v�ltoz�t�pusok:
            int egesz = 3;                                          //Eg�sz sz�m v�ltoz�

            float tort = 6.6f;                                      //R�vid t�rt v�ltoz� (Haszn�lj helyette double-t mert egyszer�bben kezelhet�)

            double hosszutort = 3.141567467;                        //Hosszabb t�rt v�ltoz�

            bool logikai = true;                                    //Logikai v�ltoz� (true / false)

            string szoveg = "alma";                                 //Sz�vegalap� v�ltoz�

            char karakter = 'a';                                    //Karakterv�ltoz�

            Console.WriteLine($"{egesz}\n{tort}\n{hosszutort}\n{logikai}\n{szoveg}\n{karakter}");       //Ha lefuttatod a programot, ki�rja a v�ltoz�k eredm�ny�t
        }

        static string mondat = "L�tj�tok? Nincs benne az f�ggv�nyben, m�gis l�tja azt amikor megh�vom";
        static void Static()
        {
            //Ha a Main f�ggv�ny kapcsosz�r�jel�n k�v�lre
            //be�rod hogy: static <v�ltoz� t�pusa> <v�ltoz� neve> ( = <v�ltoz� �rt�ke>),
            //l�tre tudsz hozni olyan v�ltoz�t amit a program b�rhol el�r

            Console.WriteLine(mondat);

            //(Ugyanez igaz a t�mb�kre, list�kra �s strukt�r�kra is)
        } 


        static void Tombok()
        {
            //A t�mb�k olyanok mint egy vonatszerelv�ny
            //K�pzelj�k el hogy az egyes kocsikba t�roljuk el az inform�ci�t

            string[] tomb = new string[3];                          //Ez egy 3 hossz�s�g� t�mb aminek az els� tagja a 0 sz�mra hallgat, a harmadik pedig a 2-re

            string[] vegtelen = new string[] { };                   //Ilyen m�don lehet "v�gtelen" hossz�s�g� t�mb�t l�trehozni 
            
            tomb[0] = "alma";                                       //Ilyen m�don tudjuk elt�rolni benne az inform�ci�t

            string[] kezdetitomb = { "alma", "k�rte", "ban�n" };    //Ez a t�mb keletkez�sekor adja meg a t�mb tagjainak �rt�k�t

            //A leggyakoribb t�mb a string
            //Mondhatjuk azt hogy nem is l�tezik, mint v�ltoz�, hanem egy karaktert�mb�t k�pvisel val�j�ban
            
            string szoveg = "alma";
            
            Console.WriteLine($"{szoveg[0]}{szoveg[1]}{szoveg[2]}{szoveg[3]}");     //Ki�rja az alma sz�t bet�nk�nt
        }


        static void Listak()
        {
            //A list�k olyanok mint a t�mb�k, csak m�shogy kell kezelni �ket
            //Ebben rejlik a nagyszer�s�g�k

            List<int> szamok = new List<int>(3);                    //Egy h�rom hossz�s�g� lista aminek az els� tagja a 0 sz�mra hallgat, a harmadik pedig a 2-re

            List<int> szamok2 = new List<int>();                    //Viszont itt nem vagyok k�teles megadni hossz�s�got �s nem kell kapcsosz�r�jellel bajl�dni

            szamok.Add(81);                                         //A list�hoz hozz�ad�s m�dja a 81 p�ld�val

            Console.WriteLine(szamok[0]);                           //Ki�rja a 81-et
        }


        struct Strukt�ra
        {
            public string cim;
            public string fohos;
            public int ertekeles;
        }
        static List<Strukt�ra> film = new List<Strukt�ra>();


        static void Strukturak()
        {
            //Ha a t�mbre �s a list�ra �gy tekint�nk hogx azok egydimenz�sak, akkor a strukt�ra k�tdimenzi�s
            //K�pzelj�k �gy el mint egy sakkt�bl�t, csak adatokkal �s nem b�bukkal

            //--------------------------
            //|       |       |        |
            //| 1.n�v |1.v�ros|1.lakc�m|
            //|       |       |        |
            //--------------------------
            //|       |       |        |
            //| 2.n�v |2.v�ros|2.lakc�m|
            //|       |       |        |
            //--------------------------
            //|       |       |        |
            //| 3.n�v |3.v�ros|3.lakc�m|
            //|       |       |        |
            //--------------------------

            Strukt�ra i1 = new Strukt�ra
            {
                cim = "Harry Potter �s a b�lcsek k�ve",             //Adatok bevitele a strukt�r�ba
                fohos = "Harry Potter",
                ertekeles = 10
            };
            film.Add(i1);

            Console.WriteLine($"{film[0].cim}, {film[0].fohos}, {film[0].ertekeles}"); //Ki�rja az els� sorban szerepl� adatokat
        }
        static void Random()
        {

        }
        static void Fuggvenyek()
        {

        }
    }
}