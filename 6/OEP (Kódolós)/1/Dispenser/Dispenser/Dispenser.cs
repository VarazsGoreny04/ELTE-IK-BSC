namespace Dispenser
{
	public class Dispenser
	{
		private double current;
		public readonly double capacity;
		public readonly double dosage;

		public Dispenser(double capacity, double dosage)
		{
			this.capacity = capacity;
			this.dosage = dosage;
			current = 0;
		}

		public void Push()
		{
			current = Math.Max(current - dosage, 0);
		}

		public void Fill()
		{
			current = capacity;
		}

		public bool IsEmpty()
		{
			return current == 0;
		}

		public double GetCurrent()
		{
			return current;
		}
	}
}