namespace SzámRend
{
	public class Registration
	{
		public virtual int GetSize()
		{
			return 0;
		}
	}

	public class File : Registration
	{
		private int size;

		public File(int size)
		{
			this.size = size;
		}

		public override int GetSize()
		{
			return size;
		}
	}

	public class Folder : Registration
	{
		private List<Registration> items;

		public Folder()
		{
			items = new List<Registration>();
		}

		public override int GetSize()
		{
			int sum = 0;
			foreach (Registration b in items)
				sum += b.GetSize();
			return sum;
		}

		public void Add(Registration r)
		{
			items.Add(r);
		}
	}

	public class FileSystem : Folder { }
}
