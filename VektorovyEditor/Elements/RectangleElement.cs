using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VektorovyEditor.Elements
{
    public class RectangleElement : BaseElement
    {
        public Rectangle Rectangle { get; set; }

        public RectangleElement(Canvas canvas, Point startPoint, Color fillColor, Color borderColor, double strokeThickness, DoubleCollection doubleCollection)
        : base(canvas, fillColor, borderColor, strokeThickness, doubleCollection, startPoint)
        {
           Rectangle = new Rectangle
            {
                Stroke = ColorBorder,
                StrokeThickness = StrokeThickness,
                StrokeDashArray = Doush,
                Fill = ColorFill,
            };
            ZIndex = 20;
            canvas.Children.Add(Rectangle);
        }

        public override void Draw(Point point)
        {
            var x = Math.Min(point.X, StartPoint.X);
            var y = Math.Min(point.Y, StartPoint.Y);

            var w = Math.Max(point.X, StartPoint.X) - x;
            var h = Math.Max(point.Y, StartPoint.Y) - y;

            Rectangle.Width = w;
            Rectangle.Height = h;

            StartPoint = new Point(x,y);
            
            Canvas.SetLeft(Rectangle, x);
            Canvas.SetTop(Rectangle, y);
            base.Draw(point);
        }

        protected override void SetZIndex(int value)
        {
            Panel.SetZIndex(Rectangle, value);
        }
    }
}
