using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedShark2.Charts
{
	internal sealed class MinorTimeSpanTicksProvider : MinorTimeProviderBase<TimeSpan>
	{
		public MinorTimeSpanTicksProvider(ITicksProvider<TimeSpan> owner) : base(owner) { }

		protected override bool IsInside(TimeSpan value, Range<TimeSpan> range)
		{
			return range.Min < value && value < range.Max;
		}
	}
}
