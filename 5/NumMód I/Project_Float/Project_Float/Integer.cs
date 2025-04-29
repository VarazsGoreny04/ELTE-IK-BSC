namespace Project_Real;

public readonly struct Integer
{
	#region Fields

	private readonly bool sign;
	private readonly Natural value;

	#endregion

	#region Properties

	public bool Sign => sign;
	public Natural Value => value;

	#endregion

	#region Constructors

	public Integer(string number)
	{
		int start = 0;

		if (!(number[0] > '0' && number[0] < '9'))
		{
			sign = number[0] switch
			{
				'+' => true,
				'-' => false,
				_ => throw new ArgumentException()
			};

			start = 1;
		}
		else
			sign = true;

		value = new Natural(number[start..]);
	}

	public Integer(bool sign, Natural value)
	{
		this.sign = sign;
		this.value = value;
	}
	
	#endregion

	#region Public methods

	public override string ToString()
	{
		return $"{(sign ? '+' : '-')}{value}";
	}

	public static bool Equals(Integer i1, Integer i2)
	{
		if (i1.sign != i2.sign)
			return false;
		else
			return Natural.Equals(i1.value, i2.value);
	}

	public static bool GreaterThan(Integer i1, Integer i2)
	{
		if (i1.sign != i2.sign)
			return i1.sign;
		else
			return Natural.GreaterThan(i1.value, i2.value);
	}

	public static Integer Add(Integer i1, Integer i2)
	{
		if (i1.sign && i2.sign)
			return new Integer(i1.sign, Natural.Add(i1.value, i2.value));
		else
		{
			if (i2.sign)
				(i1, i2) = (i2, i1);

			(bool swap, Natural value) = Natural.Substract(i1.value, i2.value);

			return new Integer(!swap, Natural.Trim(value));
		}
	}

	public static Integer Substract(Integer i1, Integer i2)
	{
		return Add(i1, new Integer(!i2.sign, i2.value));
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

	public static implicit operator Integer(string num) => new(num);
	public static bool operator ==(Integer f1, Integer f2) => Equals(f1, f2);
	public static bool operator !=(Integer f1, Integer f2) => !Equals(f1, f2);
	public static bool operator >(Integer f1, Integer f2) => GreaterThan(f1, f2);
	public static bool operator <(Integer f1, Integer f2) => GreaterThan(f2, f1);
	public static bool operator >=(Integer f1, Integer f2) => !GreaterThan(f2, f1);
	public static bool operator <=(Integer f1, Integer f2) => !GreaterThan(f1, f2);
	public static Integer operator +(Integer f1, Integer f2) => Add(f1, f2);
	public static Integer operator -(Integer f1, Integer f2) => Substract(f1, f2);
	//public static Integer operator *(Integer f1, Integer f2) => Multiply(f1, f2);

	#endregion
}