namespace Project_Real;

public readonly struct Natural
{
	#region Fields

	private static readonly Decimal ZERO = '0';
	private readonly Decimal[] digits;

	#endregion

	#region Properties

	public readonly int Length;
	public Decimal[] Digits => digits;
	private Decimal this[Index i] => digits[i];

	#endregion

	#region Constructors

	public Natural(string number = "0")
	{
		if (number.Length < 1)
			throw new ArgumentException();

		Length = number.Length;

		digits = new Decimal[Length];

		for (int i = 0; i < Length; ++i)
			digits[i] = new Decimal(number[^(i + 1)]);
	}

	public Natural(Decimal[] digits)
	{
		if (digits.Length < 1)
			throw new ArgumentException();

		Length = digits.Length;

		this.digits = digits;
	}

	#endregion

	#region Public methods

	public override string ToString()
	{
		string number = string.Empty;

		for (int i = 1; i <= digits.Length; ++i)
			number += digits[^i];

		return number;
	}

	public static Natural Trim(Natural n)
	{
		int i = 0;

		while (Decimal.Equals(n.digits[^(++i)], ZERO) && i < n.digits.Length) { }

		return new Natural(n.digits[..(n.digits.Length - i + 1)]);
	}

	public static bool Equals(Natural n1, Natural n2)
	{
		n1 = Trim(n1);
		n2 = Trim(n2);

		if (n1.Length != n2.Length)
			return false;

		int i = 0;

		while (++i < n1.Length && n1[^i] == n2[^i]) { }

		return i == n1.Length && n1[^i] == n2[^i];
	}

	public static bool GreaterThan(Natural n1, Natural n2)
	{
		n1 = Trim(n1);
		n2 = Trim(n2);

		if (n1.Length != n2.Length)
			return n1.Length > n2.Length;

		int i = 0;

		while (++i < n1.Length && n1[^i] == n2[^i]) { }

		return n1[^i] > n2[^i];
	}

	public static Natural Add(Natural n1, Natural n2, bool carry = false)
	{
		if (n1.Length < n2.Length)
			(n2, n1) = (n1, n2);

		Decimal[] result = new Decimal[n1.Length];

		for (int i = 0; i < n1.Length; ++i)
			(carry, result[i]) = Decimal.Add(n1[i], (i < n2.Length ? n2[i] : ZERO) , carry);

		if (carry)
			return new Natural([.. result, new Decimal('1')]);
		else
			return new Natural(result);
	}

	public static (bool Swap, Natural Value) Substract(Natural n1, Natural n2, bool carry = false)
	{
		bool swap = GreaterThan(n2, n1);

		if (swap)
			(n2, n1) = (n1, n2);

		Decimal[] result = new Decimal[n1.Length];

		for (int i = 0; i < Math.Max(n1.Length, n2.Length); ++i)
			(carry, result[i]) = Decimal.Substract((i < n1.Length ? n1[i] : ZERO), (i < n2.Length ? n2[i] : ZERO), carry);

		return (swap, new Natural(result));
	}

	/*public static Natural Multiply(Natural n1, Natural n2, bool carry = false)
	{
		Decimal[] result = new Decimal[n1.Length + n2.Length];


	}*/

	public override readonly bool Equals(object? obj)
	{
		return Equals(this, obj);
	}

	public override int GetHashCode()
	{
		throw new NotImplementedException();
	}

	#endregion

	#region Operators

	public static implicit operator Natural(string num) => new(num);
	public static bool operator ==(Natural f1, Natural f2) => Equals(f1, f2);
	public static bool operator !=(Natural f1, Natural f2) => !Equals(f1, f2);
	public static bool operator >(Natural f1, Natural f2) => GreaterThan(f1, f2);
	public static bool operator <(Natural f1, Natural f2) => GreaterThan(f2, f1);
	public static bool operator >=(Natural f1, Natural f2) => !GreaterThan(f2, f1);
	public static bool operator <=(Natural f1, Natural f2) => !GreaterThan(f1, f2);
	public static Natural operator +(Natural f1, Natural f2) => Add(f1, f2);
	public static Natural operator -(Natural f1, Natural f2) => Substract(f1, f2).Value;
	//public static Natural operator *(Natural f1, Natural f2) => Multiply(f1, f2);

	#endregion
}