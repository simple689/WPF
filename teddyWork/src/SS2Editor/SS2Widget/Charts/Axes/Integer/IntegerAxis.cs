using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedShark2.Charts.Axes
{
	public class IntegerAxis : AxisBase<int>
	{
		public IntegerAxis()
			: base(new IntegerAxisControl(),
				d => (int)d,
				i => (double)i)
		{

		}
	}
}
