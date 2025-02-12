using System;

namespace Rational
{
	class Rational
	{
		int n;
		int d;
		public Rational(int a, int b)
		{
			n = a;
			d = b;
		}
		public static Rational operator +(Rational a, Rational b)
		{
			return new (a.n + b.n, a.d + b.d);
		}
		public static Rational operator -(Rational a, Rational b)
		{
			return new(a.n - b.n, a.d - b.d);
		}
		public static Rational operator *(Rational a, Rational b)
		{
			return new(a.n * b.n, a.d * b.d);
		}
		public static Rational operator /(Rational a, Rational b)
		{
			return new(a.n * b.d, a.d * b.n);
		}
		public class NullDenominator : Exception { }
		public class NullDivision : Exception { }
	}
}
