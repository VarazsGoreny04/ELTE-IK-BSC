using System;

namespace TransparentStack.Type
{
	internal class Program
	{
		public static void Main()
		{
			Console.WriteLine("Hello, World!");
			TStack<int> stack = new TStack<int>();
			try
			{
				stack.Push(1);
				stack.Push(42);
				stack.Pop();
				stack.Pop();
				stack.Pop();
			}
			catch (Exception)
			{
				Console.WriteLine("Something bad happened :(");
			}
		}
	}
}