namespace Text
{
	internal class Program
	{
		static void Main(string[] args)
		{
			cw("Hello");
		}
		static void cw(string text)
		{
			for (int i = 0; i < text.Length; i++)
			{
				Console.Write(text[i]);
				Thread.Sleep(100);
			}
		}
	}
}