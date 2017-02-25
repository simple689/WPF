using System;
using System.Windows.Controls;
using System.Windows.Media;
using SpeedShark2.DataSources;
using SpeedShark2.Filters;
using SpeedShark2.PointMarkers;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using System.Windows;
using SpeedShark2.Common;
using System.Collections.Generic;

namespace SpeedShark2
{
	/// <summary>Control for plotting 2d images</summary>
	public class Plotter2D : Plotter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Plotter2D"/> class.
		/// </summary>
		public Plotter2D()
		{
			Children.Add(viewport);
		}

		private readonly Viewport2D viewport = new Viewport2D();

		/// <summary>
		/// Gets the viewport.
		/// </summary>
		/// <value>The viewport.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Viewport2D Viewport
		{
			get { return viewport; }
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DataTransform DataTransform
		{
			get { return viewport.Transform.DataTransform; }
			set { viewport.Transform = viewport.Transform.WithDataTransform(value); }
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public CoordinateTransform Transform
		{
			get { return viewport.Transform; }
			set { viewport.Transform = value; }
		}

		public void FitToView()
		{
			viewport.FitToView();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rect Visible
		{
			get { return viewport.Visible; }
			set { viewport.Visible = value; }
		}
	}
}