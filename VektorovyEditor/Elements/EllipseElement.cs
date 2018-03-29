using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VektorovyEditor.Elements
{
    public class EllipseElement : BaseElement
    {
        public Ellipse Ellipse { get; set; }

        public EllipseElement(Canvas canvas, Point startPoint, Color fillColor, Color borderColor, double strokeThickness, DoubleCollection doubleCollection) 
            : base(canvas, fillColor, borderColor, strokeThickness, doubleCollection, startPoint)
        {
            Ellipse = new Ellipse
            {
                Stroke = ColorBorder,
                StrokeThickness = StrokeThickness,
                StrokeDashArray = Doush,
                Fill = ColorFill
            };

            canvas.Children.Add(Ellipse);
        }

        public override void Draw(Point point)
        {
            var x = Math.Min(point.X, StartPoint.X);
            var y = Math.Min(point.Y, StartPoint.Y);

            var w = Math.Max(point.X, StartPoint.X) - x;
            var h = Math.Max(point.Y, StartPoint.Y) - y;

            Ellipse.Width = w;
            Ellipse.Height = h;

            Canvas.SetLeft(Ellipse, x);
            Canvas.SetTop(Ellipse, y);
            base.Draw(point);
        }

        protected override void SetZIndex(int value)
        {
            Panel.SetZIndex(Ellipse, value);
        }
    }
}
