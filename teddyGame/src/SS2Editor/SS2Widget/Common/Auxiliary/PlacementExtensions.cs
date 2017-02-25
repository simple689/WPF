using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedShark2.Charts;

namespace SpeedShark2.Common.Auxiliary
{
	internal static class PlacementExtensions
	{
		public static bool IsHorizontal(this AxisPlacement placement)
		{
			return placement == AxisPlacement.Bottom || placement == AxisPlacement.Top;
		}
	}
}
