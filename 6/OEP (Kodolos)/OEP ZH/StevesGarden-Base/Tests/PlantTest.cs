using StevesGarden;

namespace Tests;

[TestClass]
public class PlantTest
{
	public Melon melon;
	public Pumpkin pumpkin;
	public Zucchini zucchini;

	public PlantTest()
	{
		melon = new Melon(2u);
		pumpkin = new Pumpkin(2u);
		zucchini = new Zucchini(2u);
	}

	[TestMethod]
	public void CropNumberTest()
	{
		Assert.AreEqual(2u, melon.CropNumber);
		Assert.AreEqual(2u, pumpkin.CropNumber);
		Assert.AreEqual(2u, zucchini.CropNumber);

		melon = new Melon(3u);
		pumpkin = new Pumpkin(4u);
		zucchini = new Zucchini(5u);

		Assert.AreEqual(3u, melon.CropNumber);
		Assert.AreEqual(4u, pumpkin.CropNumber);
		Assert.AreEqual(5u, zucchini.CropNumber);

		melon = new Melon(0u);
		pumpkin = new Pumpkin(0u);
		zucchini = new Zucchini(0u);

		Assert.AreEqual(uint.MaxValue, melon.CropNumber - 1);
		Assert.AreEqual(uint.MaxValue, pumpkin.CropNumber - 1);
		Assert.AreEqual(uint.MaxValue, zucchini.CropNumber - 1);
	}

	[TestMethod]
	public void AreaTest()
	{
		Assert.AreEqual(5u, melon.Area);
		Assert.AreEqual(4u, pumpkin.Area);
		Assert.AreEqual(3u, zucchini.Area);

		melon = new Melon(0u);
		pumpkin = new Pumpkin(0u);
		zucchini = new Zucchini(0u);

		Assert.AreEqual(5u, melon.Area);
		Assert.AreEqual(4u, pumpkin.Area);
		Assert.AreEqual(3u, zucchini.Area);
	}

	[TestMethod]
	public void CountMethodTest()
	{
		Assert.AreEqual(0u, melon.PumpkinCount());
		Assert.AreEqual(0u, melon.ZucchiniCount());

		Assert.AreEqual(0u, pumpkin.MelonCount());
		Assert.AreEqual(0u, pumpkin.ZucchiniCount());

		Assert.AreEqual(0u, zucchini.MelonCount());
		Assert.AreEqual(0u, zucchini.PumpkinCount());

		Assert.AreEqual(2u, melon.MelonCount());
		Assert.AreEqual(2u, pumpkin.PumpkinCount());
		Assert.AreEqual(2u, zucchini.ZucchiniCount());

		melon = new Melon(3u);
		pumpkin = new Pumpkin(4u);
		zucchini = new Zucchini(5u);

		Assert.AreEqual(0u, melon.PumpkinCount());
		Assert.AreEqual(0u, melon.ZucchiniCount());

		Assert.AreEqual(0u, pumpkin.MelonCount());
		Assert.AreEqual(0u, pumpkin.ZucchiniCount());

		Assert.AreEqual(0u, zucchini.MelonCount());
		Assert.AreEqual(0u, zucchini.PumpkinCount());

		Assert.AreEqual(3u, melon.MelonCount());
		Assert.AreEqual(4u, pumpkin.PumpkinCount());
		Assert.AreEqual(5u, zucchini.ZucchiniCount());
	}

	// Ötös tesztjei

	/*
	[TestMethod]
	public void HappinessAndRipenTest()
	{
		Assert.AreEqual(4u, melon.GetHappiness());
		Assert.AreEqual(2u, pumpkin.GetHappiness());
		Assert.AreEqual(2u, zucchini.GetHappiness());

		melon.Ripen();
		pumpkin.Ripen();
		zucchini.Ripen();

		Assert.AreEqual(6u, melon.GetHappiness());
		Assert.AreEqual(6u, pumpkin.GetHappiness());
		Assert.AreEqual(4u, zucchini.GetHappiness());

		melon.Ripen();
		pumpkin.Ripen();
		zucchini.Ripen();

		Assert.AreEqual(16u, melon.GetHappiness());
		Assert.AreEqual(12u, pumpkin.GetHappiness());
		Assert.AreEqual(12u, zucchini.GetHappiness());
	}
	*/
}