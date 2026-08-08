namespace Rational;

public class Set
{
	private readonly List<Rational> numbers;

	public List<Rational> Numbers => numbers;

	public Set()
	{
		numbers = [];
	}

	public Set(List<Rational> numbers)
	{
		this.numbers = [];

		foreach (Rational number in numbers)
			Add(number);
	}

	public void Add(Rational number)
	{
		if (!numbers.Contains(number))
			numbers.Add(number);
	}

	public static Set Union(Set a, Set b)
	{
		return new Set(a.numbers.Union(b.numbers).ToList());
	}

	public static Set Intersection(Set a, Set b)
	{
		return new Set(a.numbers.Intersect(b.numbers).ToList());
	}

	public static Set Difference(Set a, Set b)
	{
		List<Rational> result = [];

		foreach (Rational number in a.numbers)
		{
			if (!b.numbers.Contains(number))
				result.Add(number);
		}

		return new Set(result);
	}

	public override string ToString()
	{
		string result = "[ ";

		foreach (Rational number in numbers)
			result += $"{number} ";

		return $"{result}]";
	}
}