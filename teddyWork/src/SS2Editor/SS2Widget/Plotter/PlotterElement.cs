using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpeedShark2.Plotter
{
    public interface IPlotterElement
    {
        void OnPlotterAttached(Plotter plotter);
        void OnPlotterDetaching(Plotter plotter);
        Plotter Plotter { get; }
    }

    public sealed class PlotterConnectionEventArgs : EventArgs
    {
        public PlotterConnectionEventArgs(Plotter plotter)
        {
            this.plotter = plotter;
        }

        private readonly Plotter plotter;
        public Plotter Plotter
        {
            get { return plotter; }
        }
    }

    public abstract class PlotterElement : FrameworkElement, IPlotterElement
    {
        private Plotter plotter;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Plotter Plotter
        {
            get { return plotter; }
        }

        public virtual void OnPlotterAttached(Plotter plotter)
        {
            this.plotter = plotter;
            RaisePlotterAttached(plotter);
        }

        public event EventHandler<PlotterConnectionEventArgs> PlotterAttached;
        protected void RaisePlotterAttached(Plotter plotter)
        {
            if (PlotterAttached != null)
            {
                PlotterAttached(this, new PlotterConnectionEventArgs(plotter));
            }
        }

        public virtual void OnPlotterDetaching(Plotter plotter)
        {
            RaisePlotterDetaching(plotter);
            this.plotter = null;
        }

        public event EventHandler<PlotterConnectionEventArgs> PlotterDetaching;
        protected void RaisePlotterDetaching(Plotter plotter)
        {
            if (PlotterDetaching != null)
            {
                PlotterDetaching(this, new PlotterConnectionEventArgs(plotter));
            }
        }
    }
}
