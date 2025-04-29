using System.Drawing;
using System.Globalization;
using static System.Math;

namespace Sokszog_pontjai
{
	internal class Program
	{

		/* ÖTLET:
		 * Csinálunk a test középpontjába egy vektort ami olyan hosszú mint a sarokpontig a középponttól 
		 * Helyvektoros forgatással megkapjuk a pontokat
		 * A két legközelebbi pontot megkeressük pithagorassal
		 * Arra a két pontra csinálunk egy egyenest
		 * Arra csinálunk egy merőlegest ami átmegy az o ponton
		 * Annál megkeressük az eredeti egyenessel akotott metszéspontot
		 * Majd megnézzük hogy a pont benne van-e a függvény két x értéke között ami megadja a test két legközelebbi pontját
		 * Ha benne van akkor az a legközelebbi, ha nem akkor az a két sarok közül ami pithagoras alapján közelebb van
		 */

		private static PointF origo = new PointF(0, 0);

		static void Main()
		{
			CultureInfo.CurrentCulture = new CultureInfo("en-US");


			#region Új poligonok hozzáadása

			List<PointF[]> vectors = new List<PointF[]>
			{
				NewPolygon(new PointF(2, 0), 4, 2),
				NewPolygon(new PointF(4, -5), 4, 3),
				NewPolygon(new PointF(4, 5), 6, 2),
				NewPolygon(new PointF(-6, 3), 5, 3),
				//NewPolygon(new PointF(20, -34), 10, 1)
			};

			#endregion

			List<double> distances = EvaluateDistances(vectors);
			Console.WriteLine($"No.{distances.IndexOf(distances.Min()) + 1} is the closest polygon");
		}

		/// <summary>
		/// Létrehoz egy poligont
		/// </summary>
		/// <returns>A test körvonalának csúcspontjai</returns>
		private static PointF[] NewPolygon(PointF middle, int numOfSides, float length)
		{
			PointF[] result = new PointF[numOfSides];

			#region A poligon csúcsainak meghatározása

			// Az origóból pontokba húzot egyenesek közti szög, a szöggel szemközti oldal hossza, az átfogó oldal hossza
			float angle = 360f / numOfSides, b = length / 2f, c = b / (float)Sin(angle / 2d * PI / 180d);
			Console.WriteLine($"Span = {c}");

			for (int i = 0; i < numOfSides; ++i)
			{
				PointF onePoint = new PointF();
				
				/*
				 * A vektorok elforgatásának szabályai szerint (https://hu.wikipedia.org/wiki/Forgat%C3%A1s (Forgatás algebrában)):
				 * P'x := Px*cos(A)-Py*sin(A)
				 * P'y := Px*sin(A)+Py*cos(A)
				 * Mivel az ortogonáltság miatt Py = 0 ezért el is hagyhatjuk a második felét 
				 */
				onePoint.X = (float)(c * Cos((-90 + (i - 0.5d) * angle) * PI / 180d) + middle.X);
				onePoint.Y = (float)(c * Sin((-90 + (i - 0.5d) * angle) * PI / 180d) + middle.Y);
				Console.WriteLine($"Alpha = {-90 + (i - 0.5d) * angle}");

				result[i] = onePoint;
				Console.WriteLine(onePoint);
			}
			Console.WriteLine();

			#endregion

			return result;
		}

		/// <summary>
		/// Kiszámolja a testek origótól mért távolságát
		/// </summary>
		/// <returns>A távolságok listája</returns>
		private static List<double> EvaluateDistances(List<PointF[]> vectors)
		{
			List<double> result = new List<double>();

			foreach (PointF[] vector in vectors)
			{
				#region A két legközelebbi pont megkeresése

				PointF[] TwoP = new PointF[2] { vector[0], vector[1] };
				double[] TwoDis = new double[2] { DisToOrigo(vector[0]), DisToOrigo(vector[1]) };
				double newDis;
				int larger;
				for (int i = 2; i < vector.Length; ++i)
				{
					newDis = DisToOrigo(vector[i]);
					larger = (TwoDis[0] < TwoDis[1]) ? 1 : 0;
					if (newDis < TwoDis[larger])
					{
						TwoP[larger] = vector[i];
						TwoDis[larger] = newDis;
					}
				}
				Console.WriteLine($"Distances of it's two closest point to the origo:\n{TwoDis[0]}, {TwoDis[1]}");

				#endregion

				#region  A két egyenes találkozási pontjának meghatározása
				// https://www.geeksforgeeks.org/program-for-point-of-intersection-of-two-lines/
				// Mivel az egyik derékszögű a másikra, nem kell vizsgálni hogy lesz-e ilyen pont
				/* 
				 * Egyenes általános alakja:
				 * Ax + By + C = 0, |A| + |B| > 0
				 */

				// A test két pontja által alkotott egyenes
				double a1 = TwoP[1].Y - TwoP[0].Y,
					   b1 = TwoP[0].X - TwoP[1].X,
					   c1 = a1 * TwoP[0].X + b1 * TwoP[0].Y;

				// A középpont és egy általunk (a meredekség ismeretében) készített pont által alkotott egyenes
				PointF origo2 = new PointF(origo.X + (TwoP[1].Y - TwoP[0].Y), origo.Y - (TwoP[1].X - TwoP[0].X));
				double a2 = origo2.Y - origo.Y,
					   b2 = origo.X - origo2.X,
					   c2 = a2 * origo.X + b2 * origo.Y;

				double determinant = a1 * b2 - a2 * b1;
				// intersection:
				PointF iS = new PointF((float)((b2 * c1 - b1 * c2) / determinant), (float)((a1 * c2 - a2 * c1) / determinant));
				Console.WriteLine($"The actual closest pont and it's distance on the line: {iS}, {DisToOrigo(iS)}");

				#endregion

				#region Bent van-e a két sarokpont által alkotott dobozban a találkozási pont

				double lowX, lowY, highX, highY;
				if (TwoP[0].X < TwoP[1].X)
				{
					lowX = TwoP[0].X; highX = TwoP[1].X;
				}
				else
				{
					lowX = TwoP[1].X; highX = TwoP[0].X;
				}
				if (TwoP[0].Y < TwoP[1].Y)
				{
					lowY = TwoP[0].Y; highY = TwoP[1].Y;
				}
				else
				{
					lowY = TwoP[1].Y; highY = TwoP[0].Y;
				}
				 
				if (lowX <= iS.X && iS.X <= highX && lowY <= iS.Y && iS.Y <= highY)
				{
					Console.WriteLine(DisToOrigo(iS));
					result.Add(DisToOrigo(iS));
				}
				else
				{
					Console.WriteLine(TwoDis.Min());
					result.Add(TwoDis.Min());
				}
				Console.WriteLine();

				#endregion
			}

			foreach (double item in result)
				Console.WriteLine(item);

			return result;
		}

		/// <summary>
		/// Az origó és egy pont közti távolságot határozza meg
		/// </summary>
		/// <returns>Két pont közti távolság</returns>
		private static double DisToOrigo(PointF point)
		{
			return Sqrt(Pow(origo.X - point.X, 2) + Pow(origo.Y - point.Y, 2));
		}
	}
}