using TextFile;

namespace Filmszinhaz
{
	public class UresFajlException : Exception { }
	public class NemMegfeleloKulcsException : Exception { }

	public class InFile
	{
		private readonly TextFileReader reader;

		public InFile(string path)
		{
			reader = new TextFileReader(path);
		}
		public void SzinhazBeolvasasa(out Szinhaz szinhaz)
		{
			if (!reader.ReadLine(out string cim))
				throw new UresFajlException();
			else if (cim != "Szinhaz")
				throw new NemMegfeleloKulcsException();

			Console.WriteLine("\nLétrejött a színház:");
			szinhaz = new Szinhaz();
			bool hasznaltSor = true;
			char[] szeparator = { ' ', '\t' };
			string sor = string.Empty;
			string[] tokenek = Array.Empty<string>();

			try
			{
				while (OlvassTovabb(ref hasznaltSor, "Vetitoterem", ref sor, ref tokenek, szeparator))
				{
					Console.WriteLine("\nMegnyílt egy vetítőterem:");
					Vetitoterem v = Vetitove(tokenek[1], tokenek[2], tokenek[3]);
					while (OlvassTovabb(ref hasznaltSor, "Eloadas", ref sor, ref tokenek, szeparator))
					{
						Console.Write("Előadás hozzáadása: ");
						try
						{
							v.UjEloadas(new Eloadas(tokenek[1].Replace('_', ' '), IdotOlvas(tokenek[2], tokenek[3])));
							Console.WriteLine("Sikeresen hozzáadva.");
						}
						catch (UtkozoEloadasException)
						{
							Console.WriteLine("Ütköző előadás!");
						}
					}
					szinhaz.TeremNyitas(v);
				}
				while (OlvassTovabb(ref hasznaltSor, "Szemely", ref sor, ref tokenek, szeparator))
				{
					Console.WriteLine("\nVásárló érkezett:");
					Szemely sz = new Szemely(tokenek[1].Replace('_', ' '), int.Parse(tokenek[2]));
					while (OlvassTovabb(ref hasznaltSor, "Tesz", ref sor, ref tokenek, szeparator))
					{
						Ido ido = IdotOlvas(tokenek[3], tokenek[4]);
						Ules ules = new Ules(tokenek[7][0], int.Parse(tokenek[7].Split(',')[1]));
						Foglalas foglalas = Foglalassa(sz.nev, ules, tokenek[6]);
						Console.Write($"{tokenek[1]}: ");
						if (!Enum.TryParse(tokenek[5], true, out Terem terem))
							throw new Exception();
						try
						{
							switch (tokenek[1])
							{
								case "Foglal":
									sz.Foglal(szinhaz, tokenek[2].Replace('_', ' '), ido, terem, foglalas);
									Console.WriteLine("Sikeres foglalás.");
									break;
								case "Lemond":
									sz.Lemond(szinhaz, tokenek[2].Replace('_', ' '), ido, terem, foglalas);
									Console.WriteLine("Sikeres lemondás.");
									break;
								case "FoglalastFizet":
									sz.FoglalastFizet(szinhaz, tokenek[2].Replace('_', ' '), ido, terem, foglalas);
									Console.WriteLine("Sikeres foglalásfizetés.");
									break;
								case "HelybenFizet":
									sz.HelybenFizet(szinhaz, tokenek[2].Replace('_', ' '), ido, terem, foglalas);
									Console.WriteLine("Sikeres helybenfizetés.");
									break;
								default: throw new NotImplementedException();
							}
						}
						catch (NincsIlyenTeremException)
						{
							Console.WriteLine("Nincs ilyen terem!");
						}
						catch (NemFoglaltException)
						{
							Console.WriteLine("Nincs leadott foglalás!");
						}
						catch (NemUresException)
						{
							Console.WriteLine("Már foglalt ülés!");
						}
						catch (NemLetezoUlesException)
						{
							Console.WriteLine("Nincs ilyen ülésszám!");
						}
						catch (CsoroException)
						{
							Console.WriteLine("Nincs elég pénze!");
						}
					}
				}
			}
			catch (UresFajlException)
			{
				Console.WriteLine("\nVége a fáljnak.\n");
			}
			finally
			{
				if (!hasznaltSor)
					Console.WriteLine($"\nVolt olyan sor ami a bemeneti fájlból nem került használatra!\n{sor}\n");
			}

		}

		private bool OlvassTovabb(ref bool hasznaltSor, string kulcs, ref string sor, ref string[] tokenek, char[] szeparator)
		{
			if (!hasznaltSor)
			{
				if (tokenek[0] == kulcs)
					return hasznaltSor = true;
				else
					return false;
			}
			else
			{
				if (!reader.ReadLine(out sor) || sor == "")
					throw new UresFajlException();
				else
				{
					tokenek = sor.Split(szeparator, StringSplitOptions.RemoveEmptyEntries);
					return hasznaltSor = tokenek[0] == kulcs;
				}
			}
		}

		public static Ido IdotOlvas(string ido1, string ido2)
		{
			string[] adat1 = ido1.Split(',');
			string[] adat2 = ido2.Split(',');
			return new Ido
			(
				new TimeSpan(int.Parse(adat1[0]), int.Parse(adat1[1]), int.Parse(adat1[2])),
				new TimeSpan(int.Parse(adat2[0]), int.Parse(adat2[1]), int.Parse(adat2[2]))
			);
		}

		public static Vetitoterem Vetitove(string tipus, string ar, string adat)
		{
			string[] adatok = adat.Split(',');
			return tipus switch
			{
				"Kozepes" => new KozepesTerem(int.Parse(ar), int.Parse(adatok[0]), int.Parse(adatok[1])),
				"Nagy" => new NagyTerem(int.Parse(ar), int.Parse(adatok[0]), int.Parse(adatok[1])),
				"Vip" => new VIPTerem(int.Parse(ar), int.Parse(adatok[0]), int.Parse(adatok[1])),
				_ => throw new NemMegfeleloKulcsException()
			};
		}

		public static Foglalas Foglalassa(string nev, Ules ules, string tipus)
		{
			return tipus switch
			{
				"Gyerek" => new Gyerek(nev, ules),
				"Diak" => new Diak(nev, ules),
				"Felnott" => new Felnott(nev, ules),
				"Nyugdijas" => new Nyugdijas(nev, ules),
				"Torzstag" => new Torzstag(nev, ules),
				_ => throw new NotImplementedException()
			};
		}
	}
}