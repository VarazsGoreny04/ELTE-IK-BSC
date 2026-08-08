using StevesGarden;

namespace Tests;

[TestClass]
public class StateTest
{
	private State seedling;
	private State green;
	private State ripe;
	private State overripe;

	public StateTest()
	{
		seedling = new Seedling();
		green = new Green();
		ripe = new Ripe();
		overripe = new Overripe();
	}

	[TestMethod]
	public void SeedlingTest()
	{
		Assert.AreEqual(2u, seedling.Happiness(new Melon(0)));
		Assert.AreEqual(1u, seedling.Happiness(new Pumpkin(0)));
		Assert.AreEqual(1u, seedling.Happiness(new Zucchini(0)));
	}

	[TestMethod]
	public void GreenTest()
	{
		Assert.AreEqual(3u, green.Happiness(new Melon(0)));
		Assert.AreEqual(3u, green.Happiness(new Pumpkin(0)));
		Assert.AreEqual(2u, green.Happiness(new Zucchini(0)));
	}

	[TestMethod]
	public void RipeTest()
	{
		Assert.AreEqual(4u, ripe.Happiness(new Melon(0)));
		Assert.AreEqual(3u, ripe.Happiness(new Pumpkin(0)));
		Assert.AreEqual(3u, ripe.Happiness(new Zucchini(0)));
	}

	[TestMethod]
	public void OverripeTest()
	{
		Assert.AreEqual(0u, overripe.Happiness(new Melon(0)));
		Assert.AreEqual(0u, overripe.Happiness(new Pumpkin(0)));
		Assert.AreEqual(0u, overripe.Happiness(new Zucchini(0)));
	}

	[TestMethod]
	public void CanHarvestTest()
	{
		Assert.IsFalse(seedling.CanHarvest());
		Assert.IsFalse(green.CanHarvest());
		Assert.IsTrue(ripe.CanHarvest());
		Assert.IsFalse(overripe.CanHarvest());
	}

	[TestMethod]
	public void RipenTest()
	{
		seedling.Ripen(ref seedling);
		Assert.AreEqual((new Green()).GetType(), seedling.GetType());

		green.Ripen(ref green);
		Assert.AreEqual((new Ripe()).GetType(), green.GetType());

		ripe.Ripen(ref ripe);
		Assert.AreEqual((new Overripe()).GetType(), ripe.GetType());

		overripe.Ripen(ref overripe);
		Assert.AreEqual((new Overripe()).GetType(), overripe.GetType());
	}
}