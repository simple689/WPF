using System.Collections.Generic;
using System.Windows;

namespace SpeedShark2
{
	public static class IPointCollectionExtensions {
		public static Rect GetBounds(this IEnumerable<Point> points) {
			return BoundsHelper.GetDataBounds(points);
		}

		public static IEnumerable<Point> Skip(this IList<Point> points, int skipCount) {
			for (int i = skipCount; i < points.Count; i++) {
				yield return points[i];
			}
		}
	}
}
