using System;

namespace Complex_menu
{
	internal class Menu
	{
		private Complex[] complex = new Complex[2];
		private IntReader reader = new IntReader();
		public Menu()
		{
			complex[0] = new Complex(1d, -1d);
			complex[1] = new Complex(2d, 2d);
		}
		internal class IntReader
		{
			private int data;
			public IntReader() { }

			internal int ReadFromConsole()
			{
				try
				{
					data = int.Parse(Console.ReadLine()!);
				}
				catch (FormatException)
				{
					data = -1;
				}
				return data;
			}
		}
		public void Run()
		{
			int n;
			do
			{
				WriteMenu();
				n = reader.ReadFromConsole();
				switch (n)
				{
					case 1:
						GetComplex();
						break;
					case 2:
						SetComplex();
						break;
					case 3:
						Add();
						break;
					case 4:
						Substract();
						break;
					case 5:
						Multiplicate();
						break;
					case 6:
						Devide();
						break;
					case 0:
						Console.WriteLine("Program is exiting");
						break;
					default:
						Console.WriteLine("Error: Given value must be an integer from the listed numbers!");
						break;
				}
				Console.ReadKey();
			} while (n != 0);
		}
		private void WriteMenu()
		{
			Console.Clear();
			Console.WriteLine("You are given 2 complex numbers:\n" + 
							  "[0] - " + complex[0].ToString() + "\n" +
							  "[1] - " + complex[1].ToString() + "\n\n" +
							  "0 - Quit\n" +
							  "1 - Get complex number\n" +
							  "2 - Set complex number\n" +
							  "3 - Add comlex numbers\n" +
							  "4 - Substract complex numbers\n" +
							  "5 - Multiply complex numbers\n" +
							  "6 - Divide complex numbers\n");
		}
		private int ReadIndex(string text)
		{
			Console.Write(text);
			int ans = int.Parse(Console.ReadLine()!);

			if (ans != 0 && ans != 1)
				throw new IndexOutOfRangeException();

			return ans;
		}
		private void GetComplex()
		{
			bool wrong = true;
			do
			{
				try
				{
					int ans = ReadIndex("Give the number of the complex number: ");
					Console.WriteLine($"The complex: " + complex[ans].ToString());
					wrong = false;
				}
				catch (FormatException)
				{
					Console.WriteLine("Error: You must give a natural number!");
				}
				catch (IndexOutOfRangeException)
				{
					Console.WriteLine("Error: The index must be 0 or 1!");
				}
			} while (wrong);
		}
		private void SetComplex()
		{
			bool wrong = true;
			do
			{
				try
				{
					int ans = ReadIndex("Give the number of the complex number: ");
					if (ans != 0 && ans != 1)
						throw new IndexOutOfRangeException();

					Console.Write("Give the first element of the complex: ");
					int newX = int.Parse(Console.ReadLine()!);
					Console.Write("Give the second element of the complex: ");
					int newI = int.Parse(Console.ReadLine()!);

					complex[ans] = new Complex(newX, newI);
					Console.WriteLine("The new complex: " + complex[ans].ToString());

					wrong = false;
				}
				catch (FormatException)
				{
					Console.WriteLine("Error: You must give a natural number!");
				}
				catch (IndexOutOfRangeException)
				{
					Console.WriteLine("Error: The index must be 0 or 1!");
				}
			} while (wrong);
		}
		private (int, int) GetIndexes()
		{
			do
			{
				try
				{
					int fst = ReadIndex("Give the number of the first complex: ");
					int snd = ReadIndex("Give the number of the second complex: ");
					return (fst, snd);
				}
				catch (FormatException)
				{
					Console.WriteLine("Error: You must give a natural number!");
				}
				catch (IndexOutOfRangeException)
				{
					Console.WriteLine("Error: The index must be 0 or 1!");
				}
			} while (true);
		}
		private void Add()
		{
			(int, int) indexes = GetIndexes();
			Console.WriteLine("The result will be: " + (complex[indexes.Item1] + complex[indexes.Item2]).ToString());
		}
		private void Substract()
		{
			(int, int) indexes = GetIndexes();
			Console.WriteLine("The result will be: " + (complex[indexes.Item1] - complex[indexes.Item2]).ToString());
		}
		private void Multiplicate()
		{
			(int, int) indexes = GetIndexes();
			Console.WriteLine("The result will be: " + (complex[indexes.Item1] * complex[indexes.Item2]).ToString());
		}
		private void Devide()
		{
			bool wrong = true;
			do
			{
				try
				{
					int fst = ReadIndex("Give the number of the first complex: ");
					int snd = ReadIndex("Give the number of the second complex: ");

					Console.WriteLine($"The result will be: " + (complex[fst] / complex[snd]).ToString());

					wrong = false;
				}
				catch (FormatException)
				{
					Console.WriteLine("Error: You must give a natural number!");
				}
				catch (IndexOutOfRangeException)
				{
					Console.WriteLine("Error: The index must be 0 or 1!");
				}
				catch (Complex.NullDenominator)
				{
					Console.WriteLine("Error: The denominator cannot be zero!");
				}
			} while (wrong);
		}
	}
}