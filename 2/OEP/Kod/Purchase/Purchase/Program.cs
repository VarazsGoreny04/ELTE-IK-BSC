﻿namespace Purchase
{
	class Program
	{
		static void Main()
		{
			try
			{
				Customer c = new ("customer1.txt");
				Store s = new ("foods.txt", "technical.txt");

				c.Purchase(s);
				s.Write();
			}
			catch(System.IO.FileNotFoundException) 
			{
				Console.WriteLine("Hibás fájlnév");
			}
		}
	}
}