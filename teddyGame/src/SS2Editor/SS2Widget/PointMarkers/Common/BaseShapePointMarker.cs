using System.Windows;
using System.Windows.Media;

namespace SpeedShark2.PointMarkers
{
    /// <summary>Abstract class that extends PointMarker and contains
    /// marker property as Pen, Brush and Size</summary>
	public abstract class BaseShapePointMarker : BasePointMarker {
		/// <summary>Size of marker in points</summary>
		public double Size {
			get { return (double)GetValue(SizeProperty); }
			set { SetValue(SizeProperty, value); }
		}

		public static readonly DependencyProperty SizeProperty =
			DependencyProperty.Register(
			  "Size",
			  typeof(double),
			  typeof(BaseShapePointMarker),
			  new FrameworkPropertyMetadata(5.0));


		/// <summary>Pen to outline marker</summary>
		public Pen Pen {
			get { return (Pen)GetValue(PenProperty); }
			set { SetValue(PenProperty, value); }
		}

		public static readonly DependencyProperty PenProperty =
			DependencyProperty.Register(
			  "Pen",
			  typeof(Pen),
			  typeof(BaseShapePointMarker),
			  new FrameworkPropertyMetadata(null));


		public Brush Fill {
			get { return (Brush)GetValue(FillProperty); }
			set { SetValue(FillProperty, value); }
		}

		public static readonly DependencyProperty FillProperty =
			DependencyProperty.Register(
			  "Fill",
			  typeof(Brush),
			  typeof(BaseShapePointMarker),
			  new FrameworkPropertyMetadata(Brushes.Red));
	}
}
