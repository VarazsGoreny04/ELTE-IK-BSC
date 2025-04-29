namespace Project_Real;

public readonly struct Decimal
{
	#region Exceptions

	private class ValueOutOfRangeException() : Exception() { }
	private class UnmatchingArrayLengthException() : Exception() { }
	private class SecondValueGreaterException() : Exception() { }
	private class ZeroDivisorException() : Exception() { }

	#endregion

	#region Fields

	private const short LENGTH = 4;
	private static readonly bool[] TEN = [false, true, false, true];
	private readonly bool[] digits;

	#endregion

	#region Properties

	public bool[] Digits => digits;
	private bool this[Index i] => digits[i];

	#endregion

	#region Constructors

	public Decimal(char character = '0')
	{
		short number = (short)(character - '0');

		if (number < 0 || number > 9)
			throw new ValueOutOfRangeException();

		digits = new bool[LENGTH];
		short pow = 0;

		do
		{
			digits[pow++] = number % 2 == 1;
			number /= 2;
		} while (number > 0);
	}

	private Decimal(bool[] bitArray)
	{
		if (bitArray.Length != LENGTH)
			throw new UnmatchingArrayLengthException();

		digits = bitArray;
	}

	#endregion

	#region Public methods

	private static bool BitEquals(bool[] b1, bool[] b2)
	{
		if (b1.Length != b2.Length)
			throw new UnmatchingArrayLengthException();

		short i = 0;
		while (++i < b1.Length && b1[^i] == b2[^i]) { }

		return i == b1.Length && b1[^i] == b2[^i];
	}

	private static bool BitGreaterThan(bool[] b1, bool[] b2)
	{
		if (b1.Length != b2.Length)
			throw new UnmatchingArrayLengthException();

		short i = 0;
		while (++i < b1.Length && b1[^i] == b2[^i]) { }

		return b1[^i] && !b2[^i];
	}

	private static bool[] TwosComplement(bool[] b)
	{
		bool[] result = new bool[b.Length];

		for (short i = 0; i < b.Length; ++i)
			result[i] = !b[i];

		return BitAdd(result, new bool[b.Length], true).Bits;
	}

	private static (bool OverFlow, bool[] Bits) BitAdd(bool[] b1, bool[] b2, bool carry = false)
	{
		if (b1.Length != b2.Length)
			throw new UnmatchingArrayLengthException();

		bool[] result = new bool[b1.Length];

		for (short i = 0; i < result.Length; ++i)
		{
			if (b1[i] && b2[i] && carry)
				result[i] = true;
			else if (b1[i] && b2[i])
				carry = true;
			else if ((b1[i] || b2[i]) && carry) { }
			else if (b1[i] || b2[i] || carry)
			{
				result[i] = true;
				carry = false;
			}
		}

		return (carry, result);
	}

	private static bool[] BitSubstract(bool[] b1, bool[] b2, bool carry = false)
	{
		bool[] b2PC;

		if (carry)
			b2PC = BitAdd(b2, new bool[b2.Length], true).Bits;
		else
			b2PC = b2;

		if (BitGreaterThan(b2, b1))
			throw new SecondValueGreaterException();
		else
			return BitAdd(b1, TwosComplement(b2PC)).Bits;
	}

	private static bool[] BitMultiply(bool[] b1, bool[] b2, bool[] carry)
	{
		bool[] result = BitMultiply(b1, b2, carry);

		return BitAdd(result, [.. carry, .. new bool[result.Length - carry.Length]]).Bits;
	}

	private static bool[] BitMultiply(bool[] b1, bool[] b2)
	{
		if (b1.Length != b2.Length)
			throw new UnmatchingArrayLengthException();

		bool[] temp;
		bool[] result = new bool[(b1.Length * 2) - 1];

		for (short i = 0; i < b2.Length; ++i)
		{
			if (b2[i])
			{
				temp = [.. new bool[i], .. b1, .. new bool[result.Length - (b1.Length + i)]];
				result = BitAdd(result, temp).Bits;
			}
		}

		return result;
	}

	private static (bool[] Whole, bool[] Remainder) BitDivision(bool[] b1, bool[] b2)
	{
		short trueIndex = (short)b2.Length;

		while (--trueIndex >= 0 && !b2[trueIndex]) { }

		if (trueIndex < 0)
			throw new ZeroDivisorException();

		bool[] dividend = b1;
		bool[] divisorEnd = b2.Take(trueIndex + 1).ToArray();
		short lenDiff = (short)(dividend.Length - divisorEnd.Length);

		bool[] whole = new bool[lenDiff]; // TODO check len

		for (short i = 0; i < lenDiff; ++i)
		{
			try
			{
				dividend = BitSubstract(dividend, [.. new bool[lenDiff - (i + 1)], .. divisorEnd, .. new bool[i]]);
			}
			catch (SecondValueGreaterException) { }
		}
	}

	#endregion

	#region Public methods

	public override readonly string ToString()
	{
		short number = 0;

		for (short i = 0; i < LENGTH; ++i)
		{
			if (digits[i])
				number += (short)Math.Pow(2d, i);
		}

		return number.ToString();
	}

	public static bool Equals(Decimal d1, Decimal d2)
	{
		return BitEquals(d1.digits, d2.digits);
	}

	public static bool GreaterThan(Decimal d1, Decimal d2)
	{
		return BitGreaterThan(d1.digits, d2.digits);
	}

	public static (bool OverFlow, Decimal Bits) Add(Decimal d1, Decimal d2, bool carry = false)
	{
		(carry, bool[] result) = BitAdd(d1.digits, d2.digits, carry);

		if (carry || !BitGreaterThan(TEN, result))
			return (true, new Decimal(BitAdd(result, TwosComplement(TEN)).Bits));
		else
			return (false, new Decimal(result));
	}

	public static (bool Borrow, Decimal Bits) Substract(Decimal d1, Decimal d2, bool carry = false)
	{
		bool[] d2PC = carry ? BitAdd(d2.digits, new bool[LENGTH], carry).Bits : d2.digits;

		if (BitGreaterThan(d2PC, d1.digits))
			return (true, new Decimal(BitSubstract(TEN, BitSubstract(d2PC, d1.digits))));
		else
			return (false, new Decimal(BitSubstract(d1.digits, d2PC)));
	}

	public static (Decimal OverFlow, Decimal Bits) Multiply(Decimal d1, Decimal d2)
	{
		bool[] bMRes = BitMultiply(d1.digits, d2.digits);


	}

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

	public static implicit operator Decimal(char num) => new(num);
	public static bool operator ==(Decimal f1, Decimal f2) => Equals(f1, f2);
	public static bool operator !=(Decimal f1, Decimal f2) => !Equals(f1, f2);
	public static bool operator >(Decimal f1, Decimal f2) => GreaterThan(f1, f2);
	public static bool operator <(Decimal f1, Decimal f2) => GreaterThan(f2, f1);
	public static bool operator >=(Decimal f1, Decimal f2) => !GreaterThan(f2, f1);
	public static bool operator <=(Decimal f1, Decimal f2) => !GreaterThan(f1, f2);
	public static (bool OverFlow, Decimal Bits) operator +(Decimal f1, Decimal f2) => Add(f1, f2);
	public static (bool Borrow, Decimal Bits) operator -(Decimal f1, Decimal f2) => Substract(f1, f2);
	public static (Decimal OverFlow, Decimal Bits) operator *(Decimal f1, Decimal f2) => Multiply(f1, f2);

	#endregion
}