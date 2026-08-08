using Tundra;

namespace TundraTest;

[TestClass]
public class PreyTest
{
	public PreyTest()
	{
		Ecosystem.ResetTurns();
	}

	[TestMethod]
	public void Lemming_ConstructorTest()
	{
		Lemming lemming = new("Test1", 200);
		Assert.AreEqual(30, lemming.Population);

		lemming = new Lemming("Test1", 199);
		Assert.AreEqual(199, lemming.Population);
	}

	[TestMethod]
	public void ArcticHare_ConstructorTest()
	{
		ArcticHare arcticHare = new("Test1", 100);
		Assert.AreEqual(20, arcticHare.Population);

		arcticHare = new ArcticHare("Test1", 99);
		Assert.AreEqual(99, arcticHare.Population);
	}

	[TestMethod]
	public void Moose_ConstructorTest()
	{
		Moose moose = new("Test1", 200);
		Assert.AreEqual(40, moose.Population);

		moose = new Moose("Test1", 199);
		Assert.AreEqual(199, moose.Population);
	}

	[TestMethod]
	public void StartTurnTest()
	{
		Lemming lemming = new("Test1", 6);
		ArcticHare arcticHare = new("Test2", 37);
		Moose moose = new("Test3", 18);

		Assert.AreEqual(0, lemming.StartTurn);
		Assert.AreEqual(0, arcticHare.StartTurn);
		Assert.AreEqual(0, moose.StartTurn);
	}

	[TestMethod]
	public void EndTurnTest()
	{
		Lemming lemming = new("Test1", 6);
		ArcticHare arcticHare = new("Test2", 37);
		Moose moose = new("Test3", 18);

		Assert.AreEqual(0, Ecosystem.TurnCounter);

		Assert.AreEqual(0, lemming.StartTurn);
		Assert.AreEqual(0, arcticHare.StartTurn);
		Assert.AreEqual(0, moose.StartTurn);

		Ecosystem.EndTurn();

		Assert.AreEqual(1, Ecosystem.TurnCounter);

		Assert.AreEqual(0, lemming.StartTurn);
		Assert.AreEqual(0, arcticHare.StartTurn);
		Assert.AreEqual(0, moose.StartTurn);
	}

	[TestMethod]
	public void Lemming_ReproduceTest()
	{
		Lemming lemming1 = new("Test1", 99);
		Lemming lemming2 = new("Test2", 100);
		Lemming lemming3 = new("Test3", 200);

		Assert.AreEqual(0, lemming1.StartTurn);
		Assert.AreEqual(0, lemming2.StartTurn);
		Assert.AreEqual(0, lemming3.StartTurn);

		Ecosystem.EndTurn();

		Assert.AreEqual(1, Ecosystem.TurnCounter);

		lemming1.Reproduce();
		lemming2.Reproduce();
		lemming3.Reproduce();

		Assert.AreEqual(99, lemming1.Population);
		Assert.AreEqual(100, lemming2.Population);
		Assert.AreEqual(30, lemming3.Population);

		Ecosystem.EndTurn();

		Assert.AreEqual(2, Ecosystem.TurnCounter);

		lemming1.Reproduce();
		lemming2.Reproduce();
		lemming3.Reproduce();

		Assert.AreEqual(198, lemming1.Population);
		Assert.AreEqual(30, lemming2.Population);
		Assert.AreEqual(60, lemming3.Population);
	}

	[TestMethod]
	public void ArcticHare_ReproduceTest()
	{
		ArcticHare arcticHare1 = new("Test1", 66);
		ArcticHare arcticHare2 = new("Test2", 67);
		ArcticHare arcticHare3 = new("Test3", 100);

		Assert.AreEqual(0, arcticHare1.StartTurn);
		Assert.AreEqual(0, arcticHare2.StartTurn);
		Assert.AreEqual(0, arcticHare3.StartTurn);

		Ecosystem.EndTurn();

		Assert.AreEqual(1, Ecosystem.TurnCounter);

		arcticHare1.Reproduce();
		arcticHare2.Reproduce();
		arcticHare3.Reproduce();

		Assert.AreEqual(66, arcticHare1.Population);
		Assert.AreEqual(67, arcticHare2.Population);
		Assert.AreEqual(20, arcticHare3.Population);

		Ecosystem.EndTurn();

		Assert.AreEqual(2, Ecosystem.TurnCounter);

		arcticHare1.Reproduce();
		arcticHare2.Reproduce();
		arcticHare3.Reproduce();

		Assert.AreEqual(99, arcticHare1.Population);
		Assert.AreEqual(20, arcticHare2.Population);
		Assert.AreEqual(30, arcticHare3.Population);
	}

	[TestMethod]
	public void Moose_ReproduceTest()
	{
		Moose moose1 = new("Test1", 166);
		Moose moose2 = new("Test2", 167);
		Moose moose3 = new("Test3", 200);

		Assert.AreEqual(0, moose1.StartTurn);
		Assert.AreEqual(0, moose2.StartTurn);
		Assert.AreEqual(0, moose3.StartTurn);

		Ecosystem.EndTurn();

		for (int i = 0; i < 3; ++i)
		{
			Assert.AreEqual(i + 1, Ecosystem.TurnCounter);

			moose1.Reproduce();
			moose2.Reproduce();
			moose3.Reproduce();

			Assert.AreEqual(166, moose1.Population);
			Assert.AreEqual(167, moose2.Population);
			Assert.AreEqual(40, moose3.Population);

			Ecosystem.EndTurn();
		}

		Assert.AreEqual(4, Ecosystem.TurnCounter);

		moose1.Reproduce();
		moose2.Reproduce();
		moose3.Reproduce();

		Assert.AreEqual(199, moose1.Population);
		Assert.AreEqual(40, moose2.Population);
		Assert.AreEqual(48, moose3.Population);
	}

	[TestMethod]
	public void DiesTest()
	{
		Prey lemming = new Lemming("Test1", 100);
		Prey arcticHare = new ArcticHare("Test2", 50);
		Prey moose = new Moose("Test3", 120);

		Assert.ThrowsException<ArgumentOutOfRangeException>(() => lemming.Dies(101));
		Assert.AreEqual(100, lemming.Dies(100));
		Assert.AreEqual(0, lemming.Population);

		Assert.ThrowsException<ArgumentOutOfRangeException>(() => arcticHare.Dies(101));
		Assert.AreEqual(15, arcticHare.Dies(30));
		Assert.AreEqual(35, arcticHare.Population);

		Assert.ThrowsException<ArgumentOutOfRangeException>(() => moose.Dies(101));
		Assert.AreEqual(46, moose.Dies(39));
		Assert.AreEqual(74, moose.Population);
	}
}