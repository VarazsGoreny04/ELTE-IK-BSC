using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Filmszinhaz.Tests
{
	[TestClass]
	public class FilmszinhazTests
	{
		public Szinhaz szinhaz;
		public Vetitoterem kozepes, nagy, vip;
		public Ido reggel;
		public Eloadas eloadas1, eloadas2, eloadas3;

		public FilmszinhazTests()
		{
			szinhaz = new Szinhaz();
			kozepes = new KozepesTerem(1000, 5, 5);
			nagy = new NagyTerem(3000, 10, 10);
			vip = new VIPTerem(3000, 10, 10);
			reggel = new Ido(new TimeSpan(8, 15, 0), new TimeSpan(11, 0, 0));
			eloadas1 = new Eloadas("Maugli", reggel);
			eloadas2 = new Eloadas("Forest Gump", reggel);
			eloadas3 = new Eloadas("Pretty woman", reggel);
		}

		[TestInitialize]
		public void EloadasHozzadasa_UtkozoEloadas()
		{
			Assert.IsFalse(kozepes.eloadasok.Contains(eloadas1));
			kozepes.UjEloadas(eloadas1);
			Assert.ThrowsException<UtkozoEloadasException>(() => kozepes.UjEloadas(eloadas2));
			Assert.IsTrue(kozepes.eloadasok.Contains(eloadas1));
			Assert.IsFalse(kozepes.eloadasok.Contains(eloadas2));

			Assert.IsFalse(nagy.eloadasok.Contains(eloadas3));
			nagy.UjEloadas(eloadas3);
			Assert.IsTrue(nagy.eloadasok.Contains(eloadas3));

			Assert.IsFalse(szinhaz.vetitotermek.Contains(kozepes));
			szinhaz.TeremNyitas(kozepes);
			Assert.IsTrue(szinhaz.vetitotermek.Contains(kozepes));

			Assert.IsFalse(szinhaz.vetitotermek.Contains(nagy));
			szinhaz.TeremNyitas(nagy);
			Assert.IsTrue(szinhaz.vetitotermek.Contains(nagy));
		}

		[TestMethod]
		public void FoglalasEsLemondas()
		{
			Szemely pisti = new Szemely("Pisti", 3000);
			Ules ules = new Ules('A', 1);
			Foglalas pistie = new Gyerek(pisti.nev, ules);

			pisti.Foglal(szinhaz, "Maugli", reggel, Terem.KOZEPES, pistie);
			Assert.IsTrue(eloadas1.FoglaltHelyek.Any(x => x == pistie));

			pisti.Lemond(szinhaz, "Maugli", reggel, Terem.KOZEPES, pistie);
			Assert.IsFalse(eloadas1.FoglaltHelyek.Any(x => x.ules == ules));
		}

		[TestMethod]
		public void HibasFoglalas_NemLetezoUles()
		{
			Szemely jozsi = new Szemely("Józsi", 2900);
			Foglalas jozsie = new Felnott(jozsi.nev, new Ules('A', 11));

			Assert.ThrowsException<NemLetezoUlesException>(() => jozsi.Foglal(szinhaz, "Pretty woman", reggel, Terem.NAGY, jozsie));
			Assert.IsFalse(eloadas3.FoglaltHelyek.Any(x => x == jozsie));
		}

		[TestMethod]
		public void HelybenFizetes_Csoro()
		{
			Szemely jozsi = new Szemely("Józsi", 2900);
			Foglalas jozsie = new Felnott(jozsi.nev, new Ules('A', 2));

			Assert.ThrowsException<CsoroException>(() => jozsi.HelybenFizet(szinhaz, "Pretty woman", reggel, Terem.NAGY, jozsie));
			Assert.IsTrue(eloadas3.FoglaltHelyek.Any(x => x == jozsie));
		}

		[TestMethod]
		public void KozepesKedvezmenyek()
		{
			Assert.AreEqual(kozepes.Szazalek(new Gyerek("Béla", new Ules('A', 1))), 40);
			Assert.AreEqual(kozepes.Szazalek(new Diak("Béla", new Ules('A', 1))), 30);
			Assert.AreEqual(kozepes.Szazalek(new Felnott("Béla", new Ules('A', 1))), 10);
			Assert.AreEqual(kozepes.Szazalek(new Nyugdijas("Béla", new Ules('A', 1))), 30);
			Assert.AreEqual(kozepes.Szazalek(new Torzstag("Béla", new Ules('A', 1))), 30);
		}

		[TestMethod]
		public void NagyKedvezmenyek()
		{
			Assert.AreEqual(nagy.Szazalek(new Gyerek("Béla", new Ules('A', 1))), 40);
			Assert.AreEqual(nagy.Szazalek(new Diak("Béla", new Ules('A', 1))), 20);
			Assert.AreEqual(nagy.Szazalek(new Felnott("Béla", new Ules('A', 1))), 0);
			Assert.AreEqual(nagy.Szazalek(new Nyugdijas("Béla", new Ules('A', 1))), 20);
			Assert.AreEqual(nagy.Szazalek(new Torzstag("Béla", new Ules('A', 1))), 30);
		}

		[TestMethod]
		public void VipKedvezmenyek()
		{
			Assert.AreEqual(vip.Szazalek(new Gyerek("Béla", new Ules('A', 1))), 0);
			Assert.AreEqual(vip.Szazalek(new Diak("Béla", new Ules('A', 1))), 0);
			Assert.AreEqual(vip.Szazalek(new Felnott("Béla", new Ules('A', 1))), 0);
			Assert.AreEqual(vip.Szazalek(new Nyugdijas("Béla", new Ules('A', 1))), 0);
			Assert.AreEqual(vip.Szazalek(new Torzstag("Béla", new Ules('A', 1))), 0);
		}
	}
}