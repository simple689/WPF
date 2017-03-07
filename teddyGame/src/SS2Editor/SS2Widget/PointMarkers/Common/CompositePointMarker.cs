using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace SpeedShark2.PointMarkers
{
    /// <summary>Composite point markers renders a specified set of markers
    /// at every point of graph</summary>
	public sealed class CompositePointMarker : BasePointMarker {
		public CompositePointMarker() { }

		public CompositePointMarker(params BasePointMarker[] markers) {
			if (markers == null)
				throw new ArgumentNullException("markers");

            foreach (BasePointMarker m in markers)
                this.markers.Add(m);
		}

		public CompositePointMarker(IEnumerable<BasePointMarker> markers) {
			if (markers == null)
				throw new ArgumentNullException("markers");
            foreach (BasePointMarker m in markers)
                this.markers.Add(m);
		}


		private readonly Collection<BasePointMarker> markers = new Collection<BasePointMarker>();
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public Collection<BasePointMarker> Markers {
			get { return markers; }
		}

		public override void Render(DrawingContext dc, Point screenPoint) {
			LocalValueEnumerator enumerator = GetLocalValueEnumerator();
			foreach (var marker in markers) {
				enumerator.Reset();
				while (enumerator.MoveNext()) {
					marker.SetValue(enumerator.Current.Property, enumerator.Current.Value);
				}

				marker.Render(dc, screenPoint);
			}
		}
	}
}
