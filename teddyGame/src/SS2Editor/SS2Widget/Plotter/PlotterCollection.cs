using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedShark2.Plotter
{
    public abstract class PlotterCollection<T> : ObservableCollection<T>
    {
        protected override void InsertItem(int index, T item)
        {
            OnItemAdding(item);
            base.InsertItem(index, item);
            OnItemAdded(item);
        }

        protected override void ClearItems()
        {
            foreach (var item in Items)
            {
                OnItemRemoving(item);
            }
            base.ClearItems();
        }

        protected override void RemoveItem(int index)
        {
            T item = Items[index];
            OnItemRemoving(item);

            base.RemoveItem(index);
        }

        protected override void SetItem(int index, T item)
        {
            T oldItem = Items[index];
            OnItemRemoving(oldItem);

            OnItemAdding(item);    
            base.SetItem(index, item);
            OnItemAdded(item);
        }

        protected virtual void OnItemAdding(T item) { }
        protected virtual void OnItemAdded(T item) { }
        protected virtual void OnItemRemoving(T item) { }
    }
}
