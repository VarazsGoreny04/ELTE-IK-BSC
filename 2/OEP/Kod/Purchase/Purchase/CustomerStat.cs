namespace Purchase
{
	class CustomerStat
	{
		public readonly string name;
		public readonly int price;
		public List<Product> cart;

		public CustomerStat(string name, int price, List<Product> shoplist)
		{
			this.name = name;
			this.price = price;
			this.cart = shoplist;
		}

		public override string ToString()
		{
			string text = $"{name}, {price}Ft\n";

			foreach (char c in text)
				text += '-';

			foreach (Product p in cart)
				text += '\n' + p.ToString();

			return text;
		}
	}
}