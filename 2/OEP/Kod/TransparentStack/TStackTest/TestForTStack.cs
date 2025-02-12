using TransparentStack.Type;

namespace TStackTest
{
	[TestClass]
	public class TestForTStack
	{
		[TestMethod]
		public void TestPop()
		{
			TStack<int> stack = new TStack<int>();
			stack.Push(1);
			stack.Push(2);
			stack.Push(3);
			int a = stack.Length;
			stack.Pop();
			int b = stack.Length;
			Assert.AreEqual(a - 1, b);
		}
		[TestMethod]
		public void TestPush()
		{
			TStack<int> stack = new TStack<int>();
			Assert.AreEqual(0, stack.Length);
			stack.Push(1);
			stack.Push(2);
			stack.Push(3);
			Assert.AreEqual(3, stack.Length);
		}
		[TestMethod]
		public void TestTop()
		{
			TStack<int> stack = new TStack<int>();
			stack.Push(1);
			stack.Push(2);
			stack.Push(42);
			Assert.AreEqual(42, stack.Top());
			stack.Pop();
			Assert.AreEqual(2, stack.Top());
		}
		[TestMethod]
		public void TestIndexing()
		{
			Assert.IsTrue(true);
		}
	}
}