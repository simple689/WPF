using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedShark2.Charts
{
	public interface IValueConversion<T>
	{
		Func<T, double> ConvertToDouble { get; set; }
		Func<double, T> ConvertFromDouble { get; set; }
	}
}
