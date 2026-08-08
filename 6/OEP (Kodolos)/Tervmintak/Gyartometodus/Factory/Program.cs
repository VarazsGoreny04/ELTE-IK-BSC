namespace Factory;

internal class Program
{
    static void Main()
    {
		IFactory porsche = new Porsche();
		IFactory cocaCola = new CocaCola();
        
        List<Product> cars = porsche.Order(2);

		Console.WriteLine($"I ordered {cars.Count} cars from {porsche.GetType().Name}:");
		cars.ForEach(car => Console.WriteLine(car.Id));

		Console.WriteLine();

		List<Product> drinks = cocaCola.Order(10);

		Console.WriteLine($"I ordered some ({drinks.Count}) coke too from {cocaCola.GetType().Name}:");
		drinks.ForEach(drink => Console.WriteLine(drink.Id));
	}
}