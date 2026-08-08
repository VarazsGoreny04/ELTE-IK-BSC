namespace Template;

internal class Program
{
    static void Main()
    {
        Animal animal1 = new Dog();
        Animal animal2 = new Cat();

		Console.WriteLine($"Animal1 is a {animal1.GetType().Name} who says *{animal1.Sound()}*.\n");
		Console.WriteLine($"Animal2 is a {animal2.GetType().Name} who says *{animal2.Sound()}*.");
    }
}