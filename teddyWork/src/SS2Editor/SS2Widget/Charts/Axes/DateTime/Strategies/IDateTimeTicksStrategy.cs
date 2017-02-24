using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedShark2.Charts
{
	public interface IDateTimeTicksStrategy
	{
		DifferenceIn GetDifference(TimeSpan span);
		bool TryGetLowerDiff(DifferenceIn diff, out DifferenceIn lowerDiff);
		bool TryGetBiggerDiff(DifferenceIn diff, out DifferenceIn biggerDiff);
	}
}
