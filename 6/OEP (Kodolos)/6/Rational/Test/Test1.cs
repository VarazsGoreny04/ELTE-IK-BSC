using Rational;

namespace Test
{
	[TestClass]
	public sealed class Test1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Rat a = new Rat(1, 2);
			Rat b = new Rat(0, 1);

			Assert.ThrowsException<Exception>(() => a / b);
		}

		[TestMethod]
		public void ConstructorTest()
		{
			Assert.ThrowsException<Exception>(() => new Rat(1, 0));
		}
	}
}