using Battleship;

namespace Test
{
	[TestClass]
	public sealed class Test1
	{
		[TestMethod]
		public void TestCoordinate()
		{
			Coordinate coordinate = new Coordinate(0, 0);

			Assert.AreEqual(0, coordinate.X);
		}
	}
}
