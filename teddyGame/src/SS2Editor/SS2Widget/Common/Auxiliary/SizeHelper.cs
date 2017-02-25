using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SpeedShark2.Common.Auxiliary
{
	internal static class SizeHelper
	{
		public static Size CreateInfiniteSize()
		{
			return new Size(Double.PositiveInfinity, Double.PositiveInfinity);
		}
	}
}
