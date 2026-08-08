namespace Complex;

public class Complex
{
	private readonly int n;
	private readonly int i;
	
	public Complex(int n, int i)
	{
		this.n = n;
		this.i = i;
	}

	public static Complex Add(Complex a, Complex b)
	{
		return new Complex(a.n + b.n, a.i + b.i);
	}

	public static Complex Sub(Complex a, Complex b)
	{
		return new Complex(a.n - b.n, a.i - b.i);
	}

	public static Complex Mul(Complex a, Complex b)
	{
		return new Complex(a.n * b.n - a.i * b.i, a.n * b.i - a.i + b.n);
	}

	public static Complex Div(Complex a, Complex b)
	{
		if (b.n == 0 && b.i == 0)
			throw new Exception();

		return new Complex(
			(a.n * b.n + a.i * b.i) / (b.n * b.n + b.i * b.i),
			(a.i * b.n - a.n * b.i) / (b.n * b.n + b.i * b.i)
			);
	}

	public override string ToString()
	{
		return $"{n} + {i}i";
	}
}