namespace Tort;

public class Set
{
	private readonly List<Rac> numbers;

	public List<Rac> Numbers => numbers;

	public Set()
	{
		numbers = [];
	}

	public Set(List<Rac> numbers)
	{
		this.numbers = [];

		foreach (Rac number in numbers)
			Add(number);
	}

	public void Add(Rac number)
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
		List<Rac> result = [];

		foreach (Rac number in a.numbers)
		{
			if (!b.numbers.Contains(number))
				result.Add(number);
		}

		return new Set(result);
	}

	public override string ToString()
	{
		string result = "[ ";

		foreach (Rac number in numbers)
			result += $"{number} ";

		return $"{result}]";
	}
}