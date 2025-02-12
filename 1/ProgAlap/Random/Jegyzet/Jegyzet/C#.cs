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
            //Az egyes változótípusok:
            int egesz = 3;                                          //Egész szám változó

            float tort = 6.6f;                                      //Rövid tört változó (Használj helyette double-t mert egyszerûbben kezelhetõ)

            double hosszutort = 3.141567467;                        //Hosszabb tört változó

            bool logikai = true;                                    //Logikai változó (true / false)

            string szoveg = "alma";                                 //Szövegalapú változó

            char karakter = 'a';                                    //Karakterváltozó

            Console.WriteLine($"{egesz}\n{tort}\n{hosszutort}\n{logikai}\n{szoveg}\n{karakter}");       //Ha lefuttatod a programot, kiírja a változók eredményét
        }

        static string mondat = "Látjátok? Nincs benne az függvényben, mégis látja azt amikor meghívom";
        static void Static()
        {
            //Ha a Main függvény kapcsoszárójelén kívülre
            //beírod hogy: static <változó típusa> <változó neve> ( = <változó értéke>),
            //létre tudsz hozni olyan változót amit a program bárhol elér

            Console.WriteLine(mondat);

            //(Ugyanez igaz a tömbökre, listákra és struktúrákra is)
        } 


        static void Tombok()
        {
            //A tömbök olyanok mint egy vonatszerelvény
            //Képzeljük el hogy az egyes kocsikba tároljuk el az információt

            string[] tomb = new string[3];                          //Ez egy 3 hosszúságú tömb aminek az elsõ tagja a 0 számra hallgat, a harmadik pedig a 2-re

            string[] vegtelen = new string[] { };                   //Ilyen módon lehet "végtelen" hosszúságú tömböt létrehozni 
            
            tomb[0] = "alma";                                       //Ilyen módon tudjuk eltárolni benne az információt

            string[] kezdetitomb = { "alma", "körte", "banán" };    //Ez a tömb keletkezésekor adja meg a tömb tagjainak értékét

            //A leggyakoribb tömb a string
            //Mondhatjuk azt hogy nem is létezik, mint változó, hanem egy karaktertömböt képvisel valójában
            
            string szoveg = "alma";
            
            Console.WriteLine($"{szoveg[0]}{szoveg[1]}{szoveg[2]}{szoveg[3]}");     //Kiírja az alma szót betûnként
        }


        static void Listak()
        {
            //A listák olyanok mint a tömbök, csak máshogy kell kezelni õket
            //Ebben rejlik a nagyszerûségük

            List<int> szamok = new List<int>(3);                    //Egy három hosszúságú lista aminek az elsõ tagja a 0 számra hallgat, a harmadik pedig a 2-re

            List<int> szamok2 = new List<int>();                    //Viszont itt nem vagyok köteles megadni hosszúságot és nem kell kapcsoszárójellel bajlódni

            szamok.Add(81);                                         //A listához hozzáadás módja a 81 példával

            Console.WriteLine(szamok[0]);                           //Kiírja a 81-et
        }


        struct Struktúra
        {
            public string cim;
            public string fohos;
            public int ertekeles;
        }
        static List<Struktúra> film = new List<Struktúra>();


        static void Strukturak()
        {
            //Ha a tömbre és a listára úgy tekintünk hogx azok egydimenzósak, akkor a struktúra kétdimenziós
            //Képzeljük úgy el mint egy sakktáblát, csak adatokkal és nem bábukkal

            //--------------------------
            //|       |       |        |
            //| 1.név |1.város|1.lakcím|
            //|       |       |        |
            //--------------------------
            //|       |       |        |
            //| 2.név |2.város|2.lakcím|
            //|       |       |        |
            //--------------------------
            //|       |       |        |
            //| 3.név |3.város|3.lakcím|
            //|       |       |        |
            //--------------------------

            Struktúra i1 = new Struktúra
            {
                cim = "Harry Potter és a bölcsek köve",             //Adatok bevitele a struktúrába
                fohos = "Harry Potter",
                ertekeles = 10
            };
            film.Add(i1);

            Console.WriteLine($"{film[0].cim}, {film[0].fohos}, {film[0].ertekeles}"); //Kiírja az elsõ sorban szereplõ adatokat
        }
        static void Random()
        {

        }
        static void Fuggvenyek()
        {

        }
    }
}