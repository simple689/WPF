using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using SpeedShark2.Charts;

namespace SpeedShark2
{
	internal static class RangeExtensions
	{
		public static double GetLength(this Range<Point> range)
		{
			Point p1 = range.Min;
			Point p2 = range.Max;

			return (p1 - p2).Length;
		}
	}
}
