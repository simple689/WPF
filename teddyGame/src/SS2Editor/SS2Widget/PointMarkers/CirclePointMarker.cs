using System.Windows;
using System.Windows.Media;

namespace SpeedShark2.PointMarkers
{
    /// <summary>Renders circle around each point of graph</summary>
	public class CirclePointMarker : ShapePointMarker {

        public override void Render(DrawingContext dc, Point screenPoint) {
			dc.DrawEllipse(Fill, Pen, screenPoint, Size / 2, Size / 2);
		}
	}

}
