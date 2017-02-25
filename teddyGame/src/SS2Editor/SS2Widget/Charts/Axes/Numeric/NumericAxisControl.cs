using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedShark2.Charts
{
	public class NumericAxisControl : AxisControl<double>
	{
		public NumericAxisControl()
		{
			LabelProvider = new ExponentialLabelProvider();
			TicksProvider = new NumericTicksProvider();
			ConvertToDouble = d => d;
			Range = new Range<double>(0, 10);
		}
	}
}
