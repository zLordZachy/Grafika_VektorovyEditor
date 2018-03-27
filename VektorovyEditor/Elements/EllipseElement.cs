using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VektorovyEditor.Elements
{
    public class EllipseElement
    {
        public Ellipse Ellipse { get; set; }
        public Canvas Canvas { get; set; }
        public Point StartPoint { get; set; }

        public int ZIndex
        {
            get => _zIndex;
            set
            {
                _zIndex = value;
                Panel.SetZIndex(Ellipse, value);
            }
        }

        public EllipseElement(Canvas canvas, Point startPoint, Color fillColor, Color borderColor, double strokeThickness, DoubleCollection doubleCollection)
        {
            Canvas = canvas;
            StartPoint = startPoint;
            SolidColorBrush border = new SolidColorBrush(borderColor);
            SolidColorBrush fill = new SolidColorBrush(fillColor);

            Ellipse = new Ellipse
            {
                Stroke = border,
                StrokeThickness = strokeThickness,
                StrokeDashArray = doubleCollection,
                Fill = fill
            };

            ZIndex = 20;
            canvas.Children.Add(Ellipse);
        }

        public void DrawEllipse(Point pos)
        {
            var x = Math.Min(pos.X, StartPoint.X);
            var y = Math.Min(pos.Y, StartPoint.Y);

            var w = Math.Max(pos.X, StartPoint.X) - x;
            var h = Math.Max(pos.Y, StartPoint.Y) - y;

            Ellipse.Width = w;
            Ellipse.Height = h;

            Canvas.SetLeft(Ellipse, x);
            Canvas.SetTop(Ellipse, y);
        }

        private int _zIndex;
    }
}
