using TextFile;

namespace Purchase
{
	class Product
	{
		public readonly string name;
		public readonly int price;

		public Product(string name, int price)
		{
			this.name = name;
			this.price = price;
		}

		static public bool Read(TextFileReader reader, out Product product)
		{
			_ = reader.ReadString(out string name);
			bool l = reader.ReadInt(out int price);
			product = new Product(name, price);
			return l;
		}

		public override string ToString()
		{
			return $"{name} : {price}";
		}
	}
}