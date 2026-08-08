namespace Dispenser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dispenser d = new Dispenser(100, 35);

            d.Fill();
            d.Push();
            d.Push();
            d.Push();

			Console.WriteLine(d.GetCurrent());
        }
    }
}
