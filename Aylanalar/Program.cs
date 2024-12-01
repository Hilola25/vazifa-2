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

			// Uchta kesishuvchi aylana bormi?
			bool foundThreeIntersecting = false;

			for (int i = 0; i < circles.Count; i++)
			{
				for (int j = i + 1; j < circles.Count; j++)
				{
					for (int k = j + 1; k < circles.Count; k++)
					{
						// Ikki aylananing kesishishini tekshirish
						double d1 = Math.Sqrt(Math.Pow(circles[i].X - circles[j].X, 2) + Math.Pow(circles[i].Y - circles[j].Y, 2));
						double d2 = Math.Sqrt(Math.Pow(circles[j].X - circles[k].X, 2) + Math.Pow(circles[j].Y - circles[k].Y, 2));
						double d3 = Math.Sqrt(Math.Pow(circles[k].X - circles[i].X, 2) + Math.Pow(circles[k].Y - circles[i].Y, 2));

						bool intersect1 = d1 <= circles[i].Radius + circles[j].Radius && d1 >= Math.Abs(circles[i].Radius - circles[j].Radius);
						bool intersect2 = d2 <= circles[j].Radius + circles[k].Radius && d2 >= Math.Abs(circles[j].Radius - circles[k].Radius);
						bool intersect3 = d3 <= circles[k].Radius + circles[i].Radius && d3 >= Math.Abs(circles[k].Radius - circles[i].Radius);

						if (intersect1 && intersect2 && intersect3)
						{
							foundThreeIntersecting = true;
							Console.WriteLine($"Uchta kesishuvchi aylana topildi: {i + 1}, {j + 1}, {k + 1}");
						}
					}
				}
			}

			if (!foundThreeIntersecting)
			{
				Console.WriteLine("Uchta kesishuvchi aylana yo'q.");
			}
			Console.ReadKey();
		}
	}

}
