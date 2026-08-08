using StevesGarden;

namespace Tests;

[TestClass]
public class GardenTest
{
	private readonly Garden garden;

	public GardenTest()
	{
		garden = Garden.Instantiate();
	}

	[TestMethod]
	public void InstantiateTest()
	{
		Garden garden2 = Garden.Instantiate();

		Assert.AreEqual(garden, garden2);
	}

	[TestMethod]
	public void CreateParcelAndToFirstFreeParcelPlantAndFreeSpacesTest()
	{
		List<uint> resultList;
		bool result;

		garden.CreateParcel(10u);

		resultList = garden.FreeSpaces();

		Assert.AreEqual(1, resultList.Count);
		Assert.AreEqual(10u, resultList[0]);

		garden.CreateParcel(11u);
		resultList = garden.FreeSpaces();

		Assert.AreEqual(2, resultList.Count);
		Assert.AreEqual(10u, resultList[0]);
		Assert.AreEqual(11u, resultList[1]);

		result = garden.ToFirstFreeParcelPlant(new Pumpkin(2u));

		resultList = garden.FreeSpaces();

		Assert.IsTrue(result);
		Assert.AreEqual(2, resultList.Count);
		Assert.AreEqual(6u, resultList[0]);
		Assert.AreEqual(11u, resultList[1]);

		result = garden.ToFirstFreeParcelPlant(new Zucchini(3u));

		resultList = garden.FreeSpaces();

		Assert.IsTrue(result);
		Assert.AreEqual(2, resultList.Count);
		Assert.AreEqual(3u, resultList[0]);
		Assert.AreEqual(11u, resultList[1]);

		result = garden.ToFirstFreeParcelPlant(new Pumpkin(4u));

		resultList = garden.FreeSpaces();

		Assert.IsTrue(result);
		Assert.AreEqual(2, resultList.Count);
		Assert.AreEqual(3u, resultList[0]);
		Assert.AreEqual(7u, resultList[1]);

		result = garden.ToFirstFreeParcelPlant(new Melon(4u));

		resultList = garden.FreeSpaces();

		Assert.IsTrue(result);
		Assert.AreEqual(2, resultList.Count);
		Assert.AreEqual(3u, resultList[0]);
		Assert.AreEqual(2u, resultList[1]);

		result = garden.ToFirstFreeParcelPlant(new Zucchini(4u));

		resultList = garden.FreeSpaces();

		Assert.IsTrue(result);
		Assert.AreEqual(2, resultList.Count);
		Assert.AreEqual(0u, resultList[0]);
		Assert.AreEqual(2u, resultList[1]);

		result = garden.ToFirstFreeParcelPlant(new Zucchini(4u));

		resultList = garden.FreeSpaces();

		Assert.IsFalse(result);
		Assert.AreEqual(2, resultList.Count);
		Assert.AreEqual(0u, resultList[0]);
		Assert.AreEqual(2u, resultList[1]);

		// Ötös tesztjei

		/*
		Assert.AreEqual(4u, garden.MelonCount());
		Assert.AreEqual(6u, garden.PumpkinCount());
		Assert.AreEqual(7u, garden.ZucchiniCount());

		Assert.AreEqual(21u, garden.HappinessMeter());

		garden.GrowPumpkins();

		Assert.AreEqual(33u, garden.HappinessMeter());

		garden.GrowMelons();
		garden.GrowPumpkins();
		garden.GrowZucchinis();

		Assert.AreEqual(62u, garden.HappinessMeter());

		garden.GrowMelons();
		garden.GrowMelons();
		garden.GrowPumpkins();
		garden.GrowZucchinis();
		garden.GrowZucchinis();

		Assert.AreEqual(0u, garden.HappinessMeter());
		*/
	}
}