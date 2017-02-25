using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedShark2.DataSources;

namespace SpeedShark2
{
	public interface IOneDimensionalChart
	{
		IPointDataSource DataSource { get; set; }
		event EventHandler DataChanged;
	}
}
