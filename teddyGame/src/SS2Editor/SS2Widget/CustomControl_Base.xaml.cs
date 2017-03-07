using SpeedShark2.Charts.Navigation;
using SpeedShark2.DataSources;
using SpeedShark2.PointMarkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpeedShark2 {
    public partial class CustomControl_Base : UserControl {
        public CustomControl_Base() {
            InitializeComponent();

            // Prepare data in arrays
            for (int i = 0; i < N; i++) {
                x[i] = i * 0.2;
                y[i] = Math.Cos(x[i]);
            }

            // Add data sources:
            yDataSource = new EnumerableDataSource<double>(y);
            yDataSource.SetYMapping(Y => Y);
            yDataSource.AddMapping(BaseShapeElementPointMarker.ToolTipTextProperty,
                Y => String.Format("Value is {0}", Y));

            xDataSource = new EnumerableDataSource<double>(x);
            xDataSource.SetXMapping(X => X);

            ds = new CompositeDataSource(xDataSource, yDataSource);
            // adding graph to plotter
            //chart = plotter.AddLineGraph(ds,
            //    new Pen(Brushes.LimeGreen, 3),
            //    new CenteredTextMarker(),
            //    new PenDescription("Cosine"));

            //chart = plotter.AddLineGraph(ds,
            //    new Pen(Brushes.LimeGreen, 3),
            //    new CircleElementPointMarker {
            //        Size = 10,
            //        Brush = Brushes.Red,
            //        Fill = Brushes.Orange
            //    },
            //    new PenDescription("Cosine"));

            //chart = plotter.AddLineGraph(ds,
            //    new Pen(Brushes.LimeGreen, 3),
            //    new CirclePointMarker {
            //        Size = 10,
            //        Fill = Brushes.Orange
            //    },
            //    new PenDescription("Cosine"));

            //chart = plotter.AddLineGraph(ds,
            //    new Pen(Brushes.LimeGreen, 3),
            //    new TrianglePointMarker {
            //        Size = 10,
            //        Fill = Brushes.Orange
            //    },
            //    new PenDescription("Cosine"));

            chart = plotter.AddLineGraph(ds,
                new Pen(Brushes.LimeGreen, 3),
                new SquareElementPointMarker {
                    Size = 10,
                    Brush = Brushes.Red,
                    Fill = Brushes.Orange
                },
                new PenDescription("Cosine"));

            plotter.Children.Add(new CursorCoordinateGraph());

            // Force evertyhing plotted to be visible
            plotter.FitToView();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (chart.MarkerGraph.DataSource != null) {
                chart.MarkerGraph.DataSource = null;
            } else {
                chart.MarkerGraph.DataSource = ds;
            }
        }

        const int N = 100;
        double[] x = new double[N];
        double[] y = new double[N];
        EnumerableDataSource<double> xDataSource;
        EnumerableDataSource<double> yDataSource;

        LineAndMarker<ElementMarkerPointsGraph> chart;
        //LineAndMarker<MarkerPointsGraph> chart;
        IPointDataSource ds;
    }
}
