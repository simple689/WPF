using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeedShark2.Filters;
using SpeedShark2.Common;
using System.Collections.Specialized;
using System.Windows;

namespace SpeedShark2.Charts
{
	public sealed class FilterCollection : D3Collection<IPointsFilter>
	{
		protected override void OnItemAdding(IPointsFilter item)
		{
			if (item == null)
				throw new ArgumentNullException("item");
		}

		protected override void OnItemAdded(IPointsFilter item)
		{
			item.Changed += OnItemChanged;
		}

		private void OnItemChanged(object sender, EventArgs e)
		{
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		protected override void OnItemRemoving(IPointsFilter item)
		{
			item.Changed -= OnItemChanged;
		}

		internal List<Point> Filter(List<Point> points, Rect screenRect)
		{
			foreach (var filter in Items)
			{
				filter.SetScreenRect(screenRect);
				points = filter.Filter(points);
			}

			return points;
		}
	}
}
