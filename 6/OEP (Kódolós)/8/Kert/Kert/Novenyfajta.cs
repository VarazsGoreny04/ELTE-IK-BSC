
namespace Kert
{
	public abstract class Novenyfajta
	{
		protected int eresiIdo;

		public int EresiIdo => eresiIdo;

		public Novenyfajta(int eresiIdo)
		{
			this.eresiIdo = eresiIdo;
		}

		public virtual bool IsZoldseg()
		{
			return false;
		}

		public virtual bool IsVirag()
		{
			return false;
		}
	}
}