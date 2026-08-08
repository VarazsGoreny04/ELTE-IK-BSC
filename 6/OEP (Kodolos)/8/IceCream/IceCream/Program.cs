namespace IceCream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IceCream chocolate = new Chocolate(10);
            IceCream vanilla = new Vanilla(12);
            IceCream punch = new Punch(10, 5);

            Cone cone = new Sweet(new List<IceCream> { chocolate, vanilla, punch });

            if (punch is Punch p)
                p.Raisins = 0;

			Console.WriteLine($"I have a {cone} cone with 3 scoops of ice cream: {cone.IceCreams[0]}, {cone.IceCreams[1]}, {cone.IceCreams[2]}");
		}
    }
}
