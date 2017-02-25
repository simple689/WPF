﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using SpeedShark2.Charts.Axes;

namespace SpeedShark2.Charts
{
	public class ToStringLabelProvider : NumericLabelProviderBase
	{
		public override UIElement[] CreateLabels(ITicksInfo<double> ticksInfo)
		{
			var ticks = ticksInfo.Ticks;

			Init(ticks);

			UIElement[] res = new UIElement[ticks.Length];
			LabelTickInfo<double> tickInfo = new LabelTickInfo<double> { Info = ticksInfo.Info };
			for (int i = 0; i < res.Length; i++)
			{
				tickInfo.Tick = ticks[i];
				tickInfo.Index = i;

				string label = GetString(tickInfo);
				res[i] = new TextBlock
				{
					Text = label,
					ToolTip = ticks[i].ToString()
				};

				ApplyCustomView(tickInfo, res[i]);
			}
			return res;
		}
	}
}
