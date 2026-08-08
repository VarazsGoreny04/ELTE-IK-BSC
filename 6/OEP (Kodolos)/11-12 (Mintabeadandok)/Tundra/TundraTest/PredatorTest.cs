using Tundra;

namespace TundraTest;

[TestClass]
public sealed class PredatorTest
{
	private SnowyOwl snowyOwl;

	public PredatorTest()
	{
		Ecosystem.ResetTurns();

		snowyOwl = new SnowyOwl("alma", 54);
	}

	[TestMethod]
	public void StartTurnTest()
	{
		SnowyOwl snowyOwl = new("Test1", 10);
		ArcticFox arcticFox = new("Test2", 23);
		PolarBear polarBear = new("Test3", 5);

		Assert.AreEqual(0, snowyOwl.StartTurn);
		Assert.AreEqual(0, arcticFox.StartTurn);
		Assert.AreEqual(0, polarBear.StartTurn);
	}

	[TestMethod]
	public void EndTurnTest()
	{
		SnowyOwl snowyOwl = new("Test1", 10);
		ArcticFox arcticFox = new("Test2", 23);
		PolarBear polarBear = new("Test3", 5);

		Assert.AreEqual(0, Ecosystem.TurnCounter);

		Assert.AreEqual(0, snowyOwl.StartTurn);
		Assert.AreEqual(0, arcticFox.StartTurn);
		Assert.AreEqual(0, polarBear.StartTurn);

		Ecosystem.EndTurn();

		Assert.AreEqual(1, Ecosystem.TurnCounter);

		Assert.AreEqual(0, snowyOwl.StartTurn);
		Assert.AreEqual(0, arcticFox.StartTurn);
		Assert.AreEqual(0, polarBear.StartTurn);
	}

	[TestMethod]
	public void SnowyOwl_ReproduceTest()
	{
		SnowyOwl snowyOwl1 = new("Test1", 10);
		SnowyOwl snowyOwl2 = new("Test2", 12);

		Assert.AreEqual(0, snowyOwl1.StartTurn);
		Assert.AreEqual(0, snowyOwl2.StartTurn);

		Ecosystem.EndTurn();

		for (int i = 0; i < 2; ++i)
		{
			Assert.AreEqual(i + 1, Ecosystem.TurnCounter);

			snowyOwl1.Reproduce();
			snowyOwl2.Reproduce();

			Assert.AreEqual(10, snowyOwl1.Population);
			Assert.AreEqual(12, snowyOwl2.Population);

			Ecosystem.EndTurn();
		}

		Assert.AreEqual(3, Ecosystem.TurnCounter);

		snowyOwl1.Reproduce();
		snowyOwl2.Reproduce();

		Assert.AreEqual(14, snowyOwl1.Population);
		Assert.AreEqual(18, snowyOwl2.Population);
	}

	[TestMethod]
	public void ArcticFox_ReproduceTest()
	{
		ArcticFox arcticFox1 = new("Test1", 10);
		ArcticFox arcticFox2 = new("Test2", 12);

		Assert.AreEqual(0, arcticFox1.StartTurn);
		Assert.AreEqual(0, arcticFox2.StartTurn);

		Ecosystem.EndTurn();

		for (int i = 0; i < 2; ++i)
		{
			Assert.AreEqual(i + 1, Ecosystem.TurnCounter);

			arcticFox1.Reproduce();
			arcticFox2.Reproduce();

			Assert.AreEqual(10, arcticFox1.Population);
			Assert.AreEqual(12, arcticFox2.Population);

			Ecosystem.EndTurn();
		}
		
		Assert.AreEqual(3, Ecosystem.TurnCounter);

		arcticFox1.Reproduce();
		arcticFox2.Reproduce();

		Assert.AreEqual(16, arcticFox1.Population);
		Assert.AreEqual(21, arcticFox2.Population);
	}

	[TestMethod]
	public void PolarBear_ReproduceTest()
	{
		PolarBear polarBear1 = new("Test1", 10);
		PolarBear polarBear2 = new("Test2", 12);

		Assert.AreEqual(0, polarBear1.StartTurn);
		Assert.AreEqual(0, polarBear2.StartTurn);

		Ecosystem.EndTurn();

		for (int i = 0; i < 7; ++i)
		{
			Assert.AreEqual(i + 1, Ecosystem.TurnCounter);

			polarBear1.Reproduce();
			polarBear2.Reproduce();

			Assert.AreEqual(10, polarBear1.Population);
			Assert.AreEqual(12, polarBear2.Population);

			Ecosystem.EndTurn();
		}
		
		Assert.AreEqual(8, Ecosystem.TurnCounter);

		polarBear1.Reproduce();
		polarBear2.Reproduce();

		Assert.AreEqual(12, polarBear1.Population);
		Assert.AreEqual(15, polarBear2.Population);
	}
}