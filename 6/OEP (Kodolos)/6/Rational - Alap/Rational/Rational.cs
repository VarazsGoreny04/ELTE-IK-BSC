namespace Rational;

public class Rational
{
	private readonly int numerator;
	private readonly int denominator;

	public Rational(int numerator, int denominator)
	{
		if (denominator == 0)
			throw new Exception();

		this.numerator = numerator;
		this.denominator = denominator;
	}

	public static Rational Add(Rational a, Rational b)
	{
		return new Rational(a.numerator * b.denominator + a.denominator * b.numerator, a.denominator * b.denominator);
	}

	public static Rational Sub(Rational a, Rational b)
	{
		return new Rational(a.numerator * b.denominator - a.denominator * b.numerator, a.denominator * b.denominator);
	}

	public static Rational Mul(Rational a, Rational b)
	{
		return new Rational(a.numerator * b.numerator, a.denominator * b.denominator);
	}

	public static Rational Div(Rational a, Rational b)
	{
		if (b.numerator == 0)
			throw new Exception();

		return new Rational(a.numerator * b.denominator, a.denominator * b.numerator);
	}

	public override string ToString()
	{
		return $"{numerator}/{denominator}";
	}

	public override bool Equals(object? obj)
	{
		return obj is Rational r && (r.numerator, r.denominator) == (numerator, denominator);
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}

	public static Rational operator +(Rational a, Rational b) => Add(a, b);
	public static Rational operator -(Rational a, Rational b) => Sub(a, b);
	public static Rational operator *(Rational a, Rational b) => Mul(a, b);
	public static Rational operator /(Rational a, Rational b) => Div(a, b);
}