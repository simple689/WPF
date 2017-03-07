using System;
using System.Windows;
using System.Windows.Media;

namespace SpeedShark2.PointMarkers
{
    /// <summary>Invokes specified delegate for rendering custon marker
    /// at every point of graph</summary>
	public sealed class DelegatePointMarker : BasePointMarker {
		public MarkerRenderer RenderCallback { get; set; }

		public DelegatePointMarker() { }
		public DelegatePointMarker(MarkerRenderer renderCallback) {
			if (renderCallback == null)
				throw new ArgumentNullException("renderCallback");
	
			RenderCallback = renderCallback;
		}

		public override void Render(DrawingContext dc, Point screenPoint) {
			RenderCallback(dc, screenPoint);
		}
	}
}
