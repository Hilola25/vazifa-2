using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aylanalar
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Aylanalar ro'yxati (Markaz koordinatalari va radiuslari)
			List<(double X, double Y, double Radius)> circles = new List<(double, double, double)>
		{
			(0, 0, 3),  // 1-a Aylana
            (4, 0, 2),  // 2-a Aylana
            (2, 2, 1),  // 3-a Aylana
            (8, 8, 2)   // 4-a Aylana
        };

			// 1) Uchta kesishuvchi aylana bormi?
			bool foundThreeIntersecting = false;

			for (int i = 0; i < circles.Count; i++)
			{
				for (int j = i + 1; j < circles.Count; j++)
				{
					for (int k = j + 1; k < circles.Count; k++)
					{
						if (AreIntersecting(circles[i], circles[j]) &&
							AreIntersecting(circles[j], circles[k]) &&
							AreIntersecting(circles[k], circles[i]))
						{
							Console.WriteLine($"Uchta kesishuvchi aylana topildi: {i + 1}, {j + 1}, {k + 1}");
							foundThreeIntersecting = true;
						}
					}
				}
			}

			if (!foundThreeIntersecting)
				Console.WriteLine("Uchta kesishuvchi aylana yo'q.");

			// 2) Alohida turgan aylanalarni aniqlash
			List<int> isolatedCircles = new List<int>();

			for (int i = 0; i < circles.Count; i++)
			{
				bool isIsolated = true;

				for (int j = 0; j < circles.Count; j++)
				{
					if (i == j) continue;

					// Tekshirish: boshqa aylana bilan kesishish yoki ichida bo'lish
					if (AreIntersecting(circles[i], circles[j]) || IsInside(circles[i], circles[j]))
					{
						isIsolated = false;
						break;
					}
				}

				if (isIsolated)
					isolatedCircles.Add(i + 1);
			}

			if (isolatedCircles.Count > 0)
			{
				Console.WriteLine("Alohida turgan aylanalar:");
				foreach (var index in isolatedCircles)
					Console.WriteLine($"Aylana {index}");
			}
			else
			{
				Console.WriteLine("Alohida turgan aylana yo'q.");
			}
			Console.ReadKey();
		}

		// Ikki aylananing kesishishini tekshiradi
		static bool AreIntersecting((double X, double Y, double Radius) a, (double X, double Y, double Radius) b)
		{
			double distance = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
			return distance <= a.Radius + b.Radius && distance >= Math.Abs(a.Radius - b.Radius);
		}

		// Bir aylana boshqa aylanani ichida joylashganligini tekshiradi
		static bool IsInside((double X, double Y, double Radius) inner, (double X, double Y, double Radius) outer)
		{
			double distance = Math.Sqrt(Math.Pow(inner.X - outer.X, 2) + Math.Pow(inner.Y - outer.Y, 2));
			return distance + inner.Radius <= outer.Radius;
		}

	}
}

