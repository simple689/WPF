using System;
using SpeedShark2;
using System.Windows;
using SpeedShark2.Navigation;
using SpeedShark2.Common;
using System.Windows.Controls;
using SpeedShark2.Charts;


namespace SpeedShark2
{
	public class TimeChartPlotter : ChartPlotter
	{
		public TimeChartPlotter()
		{
			HorizontalAxis = new HorizontalDateTimeAxis();
		}

		public void SetHorizontalAxisMapping(Func<double, DateTime> fromDouble, Func<DateTime, double> toDouble)
		{
			if (fromDouble == null)
				throw new ArgumentNullException("fromDouble");
			if (toDouble == null)
				throw new ArgumentNullException("toDouble");
	

			HorizontalDateTimeAxis axis = (HorizontalDateTimeAxis)HorizontalAxis;
			axis.ConvertFromDouble = fromDouble;
			axis.ConvertToDouble = toDouble;
		}

		public void SetHorizontalAxisMapping(double min, DateTime minDate, double max, DateTime maxDate) {
			HorizontalDateTimeAxis axis = (HorizontalDateTimeAxis)HorizontalAxis;
			
			axis.SetConversion(min, minDate, max, maxDate);
		}
	}
}
