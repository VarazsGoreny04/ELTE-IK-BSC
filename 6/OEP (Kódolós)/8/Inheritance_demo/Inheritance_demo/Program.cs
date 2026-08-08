namespace Inheritance_demo;

internal class Program
{
	static void Main()
	{
		IceCream chocolate = new Chocolate(10);
		IceCream vanilla = new Vanilla(12);
		IceCream punch = new Punch(12, 5);

		Cone cone = new Sweet(new List<IceCream> { chocolate, vanilla, punch });

		Console.WriteLine($"I have a {cone} cone with 3 scoops of ice cream: {cone.IceCreams[0]}, {cone.IceCreams[1]}, {cone.IceCreams[2]}");
	}
}
