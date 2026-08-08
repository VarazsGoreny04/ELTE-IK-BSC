namespace Tort;

public class Rac
{
	private readonly int numerator;
	private readonly int denominator;

	public Rac(int numerator, int denominator)
	{
		if (denominator == 0)
			throw new Exception();

		this.numerator = numerator;
		this.denominator = denominator;
	}

	public static Rac Add(Rac a, Rac b)
	{
		return new Rac(a.numerator * b.denominator + a.denominator * b.numerator, a.denominator * b.denominator);
	}

	public static Rac Sub(Rac a, Rac b)
	{
		return new Rac(a.numerator * b.denominator - a.denominator * b.numerator, a.denominator * b.denominator);
	}

	public static Rac Mul(Rac a, Rac b)
	{
		return new Rac(a.numerator * b.numerator, a.denominator * b.denominator);
	}

	public static Rac Div(Rac a, Rac b)
	{
		if (b.numerator == 0)
			throw new Exception();

		return new Rac(a.numerator * b.denominator, a.denominator * b.numerator);
	}

	public override string ToString()
	{
		return $"{numerator}/{denominator}";
	}

	public override bool Equals(object? obj)
	{
		return obj is Rac r && (r.numerator, r.denominator) == (numerator, denominator);
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}
	
	public static Rac operator +(Rac a, Rac b) => Add(a, b);
	public static Rac operator -(Rac a, Rac b) => Sub(a, b);
	public static Rac operator *(Rac a, Rac b) => Mul(a, b);
	public static Rac operator /(Rac a, Rac b) => Div(a, b);
}