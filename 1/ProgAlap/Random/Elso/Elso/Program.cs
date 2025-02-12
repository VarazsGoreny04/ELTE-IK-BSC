using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Elso
{
	internal class Program
	{
		static char[] nums = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',' };
		static List<double> sides = new List<double>();
		static void Main(string[] args)
		{
			Console.Write("Írd be az egyik oldal hosszát: ");
			Error();
			Console.Write("Írd be az másik oldal hosszát: ");
			Error();
			Console.WriteLine($"A téglalap területe {sides[0] * sides[1]} területnégyzet");
			Console.ReadKey();
		}
		static void Error()
		{
			string side;
			while (true)
			{
				int counter = 0;
				side = Console.ReadLine();
				for (int i = 0; i < side.Length; i++)
				{
					if (!(nums.Contains(side[i])))
						counter++;
				}
				if (counter > 0)
					Console.WriteLine("Nem megfelelő karaktertípus!");
				else if (counter == 0 && Convert.ToDouble(side) > 0)
				{
					sides.Add(Convert.ToDouble(side));
					break;
				}
			}
		}
	}
}
