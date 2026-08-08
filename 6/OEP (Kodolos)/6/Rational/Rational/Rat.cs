namespace Rational;

public class Rat
{
	private readonly int numerator;
	private readonly int denominator;

	public Rat(int numerator, int denominator)
	{
		if (denominator == 0)
			throw new Exception();

		this.numerator = numerator;
		this.denominator = denominator;
	}

	public static Rat Add(Rat a, Rat b)
	{
		return new Rat(a.numerator * b.denominator + a.denominator * b.numerator, a.denominator * b.denominator);
	}

	public static Rat Sub(Rat a, Rat b)
	{
		return new Rat(a.numerator * b.denominator - a.denominator * b.numerator, a.denominator * b.denominator);
	}

	public static Rat Mul(Rat a, Rat b)
	{
		return new Rat(a.numerator * b.numerator, a.denominator * b.denominator);
	}

	public static Rat Div(Rat a, Rat b)
	{
		if (b.numerator == 0)
			throw new Exception();

		return new Rat(a.numerator * b.denominator, a.denominator * b.numerator);
	}

	public override string ToString()
	{
		return $"{numerator}/{denominator}";
	}

	public override bool Equals(object? obj)
	{
		return obj is Rat r && (r.numerator, r.denominator) == (numerator, denominator);
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}

	public static Rat operator +(Rat a, Rat b) => Add(a, b);
	public static Rat operator -(Rat a, Rat b) => Sub(a, b);
	public static Rat operator *(Rat a, Rat b) => Mul(a, b);
	public static Rat operator /(Rat a, Rat b) => Div(a, b);
}