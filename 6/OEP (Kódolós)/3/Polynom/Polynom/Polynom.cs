namespace Polynom;

public class Polynom
{
	private readonly double[] p;
	
	public Polynom(double a, double b, double c)
	{
		p = new double[3];
		p[0] = c;
		p[1] = b;
		p[2] = a;
	}

	public double this[int ind]
	{
		get { return p[ind]; }
		set { p[ind] = value; }
	}

	public double Value(double x)
	{
		return p[2] * x * x + p[1] * x + p[0];
	}

	public static Polynom operator +(Polynom p, Polynom q)
	{
		return new Polynom(p[2] + q[2], p[1] + q[1], p[0] + q[0]);
	}

	public static Polynom operator -(Polynom p, Polynom q)
	{
		return new Polynom(p[2] - q[2], p[1] - q[1], p[0] - q[0]);
	}

	public static Polynom operator *(Polynom p, double s)
	{
		return new Polynom(p[2] * s, p[1] * s, p[0] * s);
	}

	public static Polynom Add(Polynom p, Polynom q)
	{
		return new Polynom(p[2] + q[2], p[1] + q[1], p[0] + q[0]);
	}

	public static Polynom Sub(Polynom p, Polynom q)
	{
		return new Polynom(p[2] - q[2], p[1] - q[1], p[0] - q[0]);
	}

	public static Polynom Mul(Polynom p, double s)
	{
		return new Polynom(p[2] * s, p[1] * s, p[0] * s);
	}

	public override string ToString()
	{
		return $"{p[2]}x^2 + {p[1]}x + {p[0]}";
	}
}