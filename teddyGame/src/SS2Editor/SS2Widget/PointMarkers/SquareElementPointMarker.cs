using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SpeedShark2.PointMarkers {
    public class SquareElementPointMarker : BaseShapeElementPointMarker {
        public override UIElement CreateMarker() {
            _canvas = new Canvas() {
                Width = 10,
                Height = Size
            };
            _canvas.Width = Size;
            _canvas.Height = Size;
            _canvas.Background = Brush;
            if (ToolTipText != String.Empty) {
                ToolTip tt = new ToolTip();
                tt.Content = ToolTipText;
                _canvas.ToolTip = tt;
            }
            _canvas.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(canvas_MouseLeftButtonDown);
            _canvas.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(canvas_MouseLeftButtonUp);
            _canvas.PreviewMouseMove += new MouseEventHandler(canvas_MouseMove);
            return _canvas;
        }

        public override void SetPosition(UIElement marker, Point screenPoint) {
            Canvas.SetLeft(marker, screenPoint.X - Size / 2);
            Canvas.SetTop(marker, screenPoint.Y - Size / 2);
            _marker = marker;
            _screenPoint = screenPoint;
        }

        public void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
        }

        public void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
        }

        public void canvas_MouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                var pCanvas = e.GetPosition(_canvas);
                Canvas.SetLeft(_marker, pCanvas.X - (_screenPoint.X - Size / 2));
                Canvas.SetTop(_marker, pCanvas.Y - (_screenPoint.Y - Size / 2));
            }
        }

        private Canvas _canvas;
        private UIElement _marker;
        private Point _screenPoint;
    }
}
