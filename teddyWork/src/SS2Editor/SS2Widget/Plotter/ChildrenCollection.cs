using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedShark2.Plotter
{
    public sealed class ChildrenCollection : PlotterCollection<IPlotterElement>
    {
        protected override void OnItemAdding(IPlotterElement item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
        }

        protected override void ClearItems()
        {
            var items = new List<IPlotterElement>(base.Items);
            foreach (var item in items)
            {
                Remove(item);
            }
        }
    }
}
