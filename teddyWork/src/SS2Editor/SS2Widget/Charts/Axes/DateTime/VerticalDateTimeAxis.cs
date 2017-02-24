using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedShark2.Charts
{
	public class VerticalDateTimeAxis : DateTimeAxis
	{
		public VerticalDateTimeAxis()
		{
			Placement = AxisPlacement.Left;
		}

		protected override void ValidatePlacement(AxisPlacement newPlacement)
		{
			if (newPlacement == AxisPlacement.Bottom || newPlacement == AxisPlacement.Top)
				throw new ArgumentException(Properties.Resources.VerticalAxisCannotBeHorizontal);
		}
	}
}
