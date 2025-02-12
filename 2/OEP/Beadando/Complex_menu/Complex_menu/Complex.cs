using System;

namespace Complex_menu
{
	internal class Complex
	{
		public class NullDenominator : Exception { }
		public class NullDivision : Exception { }

		public double x, i;
		public Complex(double a, double b)
		{
			x = a;
			i = b;
		}
		public static Complex operator +(Complex a, Complex b)
		{
			return new(a.x + b.x, a.i + b.i);
		}
		public static Complex operator -(Complex a, Complex b)
		{
			return new(a.x - b.x, a.i - b.i);
		}
		public static Complex operator *(Complex a, Complex b)
		{
			return new(a.x * b.x - a.i * b.i, a.x * b.i + a.i * b.x);
		}
		public static Complex operator /(Complex a, Complex b)
		{
			double denom = b.Denominator();

			if (denom == 0d)
				throw new NullDenominator();

			return new((a.x * b.x + a.i * b.i) / denom, (a.i * b.x - a.x * b.i) / denom);
		}
		public double Denominator()
		{
			return Math.Pow(x, 2) + Math.Pow(i, 2);
		}
		public override string ToString()
		{
			if (i < 0)
				return $"{x} - {Math.Abs(i)}i";
			else
				return $"{x} + {Math.Abs(i)}i";
		}
	}
}