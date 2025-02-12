using System.ComponentModel.DataAnnotations;
using TextFile;

namespace Purchase
{
	class Customer
	{
		public readonly string name;
		public readonly bool card;
		private int cardPoints;
		public int balance { get; private set; }
		private readonly List<string> list = new List<string>();
		public List<Product> cart = new List<Product>();

		private int cartValue
		{
			get
			{
				int sum = 0;
				foreach (Product item in cart)
					sum += item.price;
				return sum;
			}
			set { }
		}

		public Customer(string filename)
		{
			TextFileReader reader = new TextFileReader(filename);
			reader.ReadString(out string str);
			name = str;
			Random rand = new Random();
			card = Convert.ToBoolean(rand.Next(0, 2));
			balance = rand.Next(5000, 10001);
			while (reader.ReadString(out str))
				list.Add(str);
			
		}

		public void Purchase(Store store)
		{
			Console.WriteLine($"{name} vásárló megvette az alábbi árukat: ");

			foreach (string productName in list)
			{
				if (LinSearch(productName, store.foods, out Product product))
				{
					Drag(product, ref store.foods);
					Console.WriteLine($"{product.name} {product.price}");
				}
			}

			foreach (string productName in list)
			{
				if (MinSearch(productName, store.technical, out Product product))
				{
					Drag(product, ref store.technical);
					Console.WriteLine($"{product.name} {product.price}");
				}
			}

			int cv = cartValue;
			store.AddBuy(new CustomerStat(name, cv, cart));
			if (cardPoints >= 100)
			{
				balance -= cv - (cv / 10);
				cardPoints += ((cv - (cv / 10)) / 10) - 100;
			}
			else
			{
				balance -= cv;
				cardPoints += cv / 10;
			}
			cart = new List<Product>();
		}

		private void Drag(Product product, ref Department department)
		{
			int allPrice = cartValue + product.price;
			if (allPrice - (card && cardPoints >= 100 ? allPrice / 10 : 0) > balance)
				return;
			
			department.stock.Remove(product);
			cart.Add(product);
		}

		private static bool LinSearch(string name, Department d, out Product product)
		{
			product = null!;
			bool l = false;
			foreach (Product p in d.stock)
			{
				if (l = (p.name == name))
				{
					product = p;
					break;
				}
			}
			return l;
		}

		private static bool MinSearch(string name, Department d, out Product product)
		{
			product = null!;
			bool l = false;
			int min = 0;
			foreach (Product p in d.stock)
			{
				if (p.name != name)
					continue;
				if (!l)
				{
					l = true;
					min = p.price;
					product = p;
				}
				else if(min > p.price)
				{
					min = p.price;
					product = p;
				}
			}
			return l;
		}
	}
}