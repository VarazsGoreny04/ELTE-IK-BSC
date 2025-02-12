using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextFile;

namespace Cactus
{
	class Program
	{
		struct Cactus
		{
			public string name;
			public string country;
			public string color;
			public int height;
		}

		static void Main()
		{
			TextFileReader reader = new TextFileReader("inp.txt");
			using StreamWriter writer1 = new(@"..\..\..\out1.txt");
			using StreamWriter writer2 = new(@"..\..\..\out2.txt");
			using StreamWriter writer3 = new(@"..\..\..\out3.txt");

			int max = 0, sumHeight = 0, count = 0;
			string maxName = null;
			List<string> colorsOfCacti = new List<string>();
			List<int> numbersOfCacti = new List<int>();

			Dictionary<string, int> cica = new Dictionary<string, int>();
			if (++cica["alma"] == 8);
			
			while (ReadCactus(ref reader, out Cactus cactus))
			{
				if ("piros" == cactus.color) writer1.WriteLine(cactus.name);
				if ("mexico" == cactus.country) writer2.WriteLine(cactus.name);
				if ("piros" == cactus.color && "mexico" == cactus.country) writer3.WriteLine(cactus.name);

				;
				if (cactus.height > max)
				{
					max = cactus.height;
					maxName = cactus.name;
				}

				if (!colorsOfCacti.Contains(cactus.color))
				{
					colorsOfCacti.Add(cactus.color);
					numbersOfCacti.Add(1);
				}
				else
					++numbersOfCacti[colorsOfCacti.IndexOf(cactus.color)];

				++count;
				sumHeight += cactus.height;
			}
			Console.WriteLine($"A legmagasabb kaktuszfajta: {maxName}");
			int maxDb = numbersOfCacti.Max();
			Console.WriteLine($"{colorsOfCacti[numbersOfCacti.IndexOf(maxDb)]} és {maxDb}");
			Console.WriteLine($"Átlagmagasság: {(double)sumHeight / count}");
		}

		static bool ReadCactus(ref TextFileReader reader, out Cactus cactus)
		{
			bool l = reader.ReadString(out cactus.name);
			reader.ReadString(out cactus.country);
			reader.ReadString(out cactus.color);
			reader.ReadInt(out cactus.height);
			return l;
		}

		/// <summary>
		/// Feladatok
		/// </summary>
		/// Keressük meg a legmagasabb kaktusz fajtáját
		/// Melyik színű kaktuszból van a legtöbb és mennyi?
		/// Átlagosan milyen magasak a növények az "adatbázisban"?
		/// Extra feladatok: inp2.txt (Teams-en az óra mappájában) + amit majd éppen kitalálok feladat
	}
}
