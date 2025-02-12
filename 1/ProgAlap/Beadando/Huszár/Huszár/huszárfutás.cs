using System;
using System.Collections.Generic;
namespace Huszár
{
    internal class Knight
    {
        static int[] start = new int[3];                    //A bemenetet tartalmazó tömb ({sorindex 1-8} {oszlopindex 1-8} {maximális lépésszám 0-20})
        struct Moves                                        //Az eddig megtalált lépéseket tartalmazó struktúra
        {
            public int Row, Cullumn;
        }
        static List<Moves> moves = new List<Moves>();
        static void Main(string[] args)
        {
            Input();
            Calculation();
            Display();
        }
        static void Input()
        {
            Console.Error.WriteLine("Add meg a kezdő pozíciót és az onnan számított lépések számát!\n({sorindex} {oszlopindex} {maximális lépésszám})");
			bool typeError = false, dataError = false, rowError = false, cullumnError = false, moveError = false;
			bool lengthError;
			do
			{
				string line = Console.ReadLine()!;
				string[] pieces = line.Split();
				//Ha nem megfelelő a karaktersorozat hosszúsága
				if (!(lengthError = pieces.Length != 3))
				{
					rowError = !int.TryParse(pieces[0], out start[0]);
					cullumnError = !int.TryParse(pieces[1], out start[1]);
					moveError = !int.TryParse(pieces[2], out start[2]);
					//Ha nem megfelelő az adattípus
					typeError = rowError || cullumnError || moveError;
					//Ha nem megfelelő az adatok értéke
					dataError = start[0] < 1 || start[0] > 8 || start[1] < 1 || start[1] > 8 || start[2] < 0 || start[2] > 20;
					if (typeError)
						Console.Error.WriteLine("Nem megfelelő adattípus! ({sorindex} {oszlopindex} {maximális lépésszám})");
					else if (dataError)
						Console.Error.WriteLine("Az egyik adat átlépte a maximális vagy minimális értéket amit felvehet! ([1..8] [1..8] [0..20])");
				}
				else
					Console.Error.WriteLine("Az bemenő adatok száma nem megfelelő! [3]");
			} while (lengthError || typeError || dataError);
			//Kezdő pozíció hozzáadása a megtalált lépésekhez
			Moves i1 = new Moves
            {
                Row = start[0],
                Cullumn = start[1]
            };
            moves.Add(i1);
        }
        static void Calculation()
        {
            //Az új lépések sor- és oszlopszáma
            int lastChecked = 1, row, cullumn;
            //A lépések számáig
            for (int i = 0; i < start[2]; i++)
            {
                if (start[2] > 5)
                    break;
                //Az utoljára tesztelt lépéstől
                int j = lastChecked - 1;
                lastChecked = moves.Count;
                while (j < lastChecked)
                {
                    for (int k = -1; k <= 1; k += 2)
                    {
                        for (int l = -2; l <= 2; l += 4)
                        {
                            row = moves[j].Row + k;
                            cullumn = moves[j].Cullumn + l;
                            if (row >= 1 && row <= 8 && cullumn >= 1 && cullumn <= 8)
                            {
                                Moves i1 = new Moves { Row = row, Cullumn = cullumn };
                                moves.Add(i1);
                            }
                        }
                    }
                    for (int k = -2; k <= 2; k += 4)
                    {
                        for (int l = -1; l <= 1; l += 2)
                        {
                            row = moves[j].Row + k;
                            cullumn = moves[j].Cullumn + l;
                            if (row >= 1 && row <= 8 && cullumn >= 1 && cullumn <= 8)
                            {
                                Moves i1 = new Moves { Row = row, Cullumn = cullumn };
                                moves.Add(i1);
                            }
                        }
                    }
                    j++;
                }
            }
        }
        static void Display()
        {
            Console.WriteLine();

            if (start[2] < 6)
            {
                //Csinálja meg mind a nyolc sorra
                for (int i = 1; i <= 8; i++)
                {
                    //Megjelöli a sor mezőit ahova vezet lépés
                    List<int> markedCullumns = new List<int>();
                    for (int j = 0; j < moves.Count; j++)
                    {
                        if (moves[j].Row == i && !markedCullumns.Contains(j))
                            markedCullumns.Add(moves[j].Cullumn);
                    }
                    markedCullumns.Sort();
                    string resultOfARow = "\t";
                    for (int j = 1; j <= 8; j++)
                    {
                        if (markedCullumns.Contains(j))
                            resultOfARow += "* ";
                        else
                            resultOfARow += "˙ ";
                    }
                    Console.WriteLine(resultOfARow);
                }
            }
            else
            {
                for (int i = 0; i < 8; i++)
                    Console.WriteLine("\t* * * * * * * * ");
            }
        }
    }
}