using StevesGarden;

namespace Tests;

[TestClass]
public class ParcelTest
{
	public readonly Parcel parcel1;
	public readonly Parcel parcel2;

	public ParcelTest()
	{
		parcel1 = new Parcel(10u);
		parcel2 = new Parcel(9u);
	}

	[TestMethod]
	public void AreaTest()
	{
		Assert.AreEqual(10u, parcel1.Area);
		Assert.AreEqual(9u, parcel2.Area);

		Assert.AreEqual(10u, parcel1.FreeSpace);
		Assert.AreEqual(9u, parcel2.FreeSpace);
	}

	[TestMethod]
	public void PlantTest()
	{
		Assert.AreEqual(10u, parcel1.Area);
		Assert.AreEqual(9u, parcel2.Area);
		Assert.AreEqual(10u, parcel1.FreeSpace);
		Assert.AreEqual(9u, parcel2.FreeSpace);

		parcel1.Plant(new Zucchini(2u));

		Assert.AreEqual(10u, parcel1.Area);
		Assert.AreEqual(9u, parcel2.Area);
		Assert.AreEqual(7u, parcel1.FreeSpace);
		Assert.AreEqual(9u, parcel2.FreeSpace);

		parcel1.Plant(new Pumpkin(2u));

		Assert.AreEqual(10u, parcel1.Area);
		Assert.AreEqual(9u, parcel2.Area);
		Assert.AreEqual(3u, parcel1.FreeSpace);
		Assert.AreEqual(9u, parcel2.FreeSpace);

		parcel1.Plant(new Zucchini(2u));

		Assert.AreEqual(10u, parcel1.Area);
		Assert.AreEqual(9u, parcel2.Area);
		Assert.AreEqual(0u, parcel1.FreeSpace);
		Assert.AreEqual(9u, parcel2.FreeSpace);

		parcel2.Plant(new Melon(2u));

		Assert.AreEqual(10u, parcel1.Area);
		Assert.AreEqual(9u, parcel2.Area);
		Assert.AreEqual(0u, parcel1.FreeSpace);
		Assert.AreEqual(4u, parcel2.FreeSpace);

		parcel2.Plant(new Melon(2u));

		Assert.AreEqual(10u, parcel1.Area);
		Assert.AreEqual(9u, parcel2.Area);
		Assert.AreEqual(0u, parcel1.FreeSpace);
		Assert.AreEqual(4u, parcel2.FreeSpace);
	}

	[TestMethod]
	public void CountTest()
	{
		Assert.AreEqual(0u, parcel1.MelonCount());
		Assert.AreEqual(0u, parcel1.PumpkinCount());
		Assert.AreEqual(0u, parcel1.ZucchiniCount());
		Assert.AreEqual(0u, parcel2.MelonCount());
		Assert.AreEqual(0u, parcel2.PumpkinCount());
		Assert.AreEqual(0u, parcel2.ZucchiniCount());

		parcel1.Plant(new Melon(2u));

		Assert.AreEqual(2u, parcel1.MelonCount());
		Assert.AreEqual(0u, parcel1.PumpkinCount());
		Assert.AreEqual(0u, parcel1.ZucchiniCount());
		Assert.AreEqual(0u, parcel2.MelonCount());
		Assert.AreEqual(0u, parcel2.PumpkinCount());
		Assert.AreEqual(0u, parcel2.ZucchiniCount());

		parcel1.Plant(new Melon(5u));
		parcel1.Plant(new Melon(2u));
		parcel2.Plant(new Zucchini(3u));

		Assert.AreEqual(7u, parcel1.MelonCount());
		Assert.AreEqual(0u, parcel1.PumpkinCount());
		Assert.AreEqual(0u, parcel1.ZucchiniCount());
		Assert.AreEqual(0u, parcel2.MelonCount());
		Assert.AreEqual(0u, parcel2.PumpkinCount());
		Assert.AreEqual(3u, parcel2.ZucchiniCount());

		parcel2.Plant(new Zucchini(4u));
		parcel2.Plant(new Pumpkin(3u));
		parcel2.Plant(new Zucchini(3u));
		parcel2.Plant(new Zucchini(1u));

		Assert.AreEqual(7u, parcel1.MelonCount());
		Assert.AreEqual(0u, parcel1.PumpkinCount());
		Assert.AreEqual(0u, parcel1.ZucchiniCount());
		Assert.AreEqual(0u, parcel2.MelonCount());
		Assert.AreEqual(0u, parcel2.PumpkinCount());
		Assert.AreEqual(10u, parcel2.ZucchiniCount());
	}

	// Ötös tesztjei

	/*
	[TestMethod]
	public void HappinessAndRipenTest()
	{
		parcel1.Plant(new Zucchini(2u));
		parcel2.Plant(new Zucchini(2u));

		Assert.AreEqual(2u, parcel1.SumHappiness());
		Assert.AreEqual(2u, parcel2.SumHappiness());

		parcel1.GrowZucchinis();

		Assert.AreEqual(4u, parcel1.SumHappiness());
		Assert.AreEqual(2u, parcel2.SumHappiness());

		parcel2.GrowZucchinis();

		Assert.AreEqual(4u, parcel1.SumHappiness());
		Assert.AreEqual(4u, parcel2.SumHappiness());

		parcel1.GrowZucchinis();
		parcel2.GrowZucchinis();

		Assert.AreEqual(12u, parcel1.SumHappiness());
		Assert.AreEqual(12u, parcel2.SumHappiness());

		parcel1.Plant(new Melon(3u));
		parcel2.Plant(new Pumpkin(4u));

		Assert.AreEqual(18u, parcel1.SumHappiness());
		Assert.AreEqual(16u, parcel2.SumHappiness());

		parcel1.GrowMelons();
		parcel2.GrowMelons();
		parcel1.GrowPumpkins();
		parcel2.GrowPumpkins();
		parcel1.GrowZucchinis();
		parcel2.GrowZucchinis();

		Assert.AreEqual(9u, parcel1.SumHappiness());
		Assert.AreEqual(12u, parcel2.SumHappiness());
	}
	*/
}