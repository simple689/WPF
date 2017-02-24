using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SpeedShark2.Plotter
{
    public abstract class Plotter : ContentControl
    {
        protected Plotter()
        {
            UpdateUIParts();

            children.CollectionChanged += OnChildrenCollectionChanged;
            Loaded += OnPlotterLoaded;

            ContextMenu = null;
        }

        private const string templateKey = "defaultPlotterTemplate";
        private const string styleKey = "defaultPlotterStyle";
        private void UpdateUIParts()
        {
            ResourceDictionary dict = new ResourceDictionary
            {
                Source = new Uri("/SpeedShark2;component/Plotter/PlotterStyle.xaml", UriKind.Relative)
            };

            Style = (Style)dict[styleKey];

            ControlTemplate template = (ControlTemplate)dict[templateKey];
            Template = template;
            ApplyTemplate();
        }

        private void OnPlotterLoaded(object sender, RoutedEventArgs e)
        {
            Focus();

            OnLoaded();
        }

        protected virtual void OnLoaded() { }


        private void OnChildrenCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (IPlotterElement item in e.NewItems)
                {
                    OnChildAdded(item);
                }
            }
            if (e.OldItems != null)
            {
                foreach (IPlotterElement item in e.OldItems)
                {
                    OnChildRemoving(item);
                }
            }
        }

        private readonly ChildrenCollection children = new ChildrenCollection();

    }
}
