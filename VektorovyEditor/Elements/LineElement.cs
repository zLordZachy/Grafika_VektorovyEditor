using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VektorovyEditor.Elements
{
    public class LineElement : BaseElement
    {
        public Line Line { get; set; }
  
        public LineElement(Canvas canvas, Point startPoint, Color fillColor, Color borderColor, double strokeThickness, DoubleCollection doubleCollection)
            : base(canvas, fillColor, borderColor, strokeThickness, doubleCollection, startPoint)
        {
            Line = new Line
            {
                Stroke = ColorBorder,
                StrokeThickness = StrokeThickness,
                StrokeDashArray = Doush,
                Fill = ColorFill,
                X1 = StartPoint.X,
                Y1 = StartPoint.Y,
                X2 = StartPoint.X,
                Y2 = StartPoint.Y,
            };

            ZIndex = 50;
            canvas.Children.Add(Line);
        }

        public override void Draw(Point point)
        {
            Line.X2 = point.X;
            Line.Y2 = point.Y;
            base.Draw(point);
        }

        protected override void SetZIndex(int value)
        {
            Panel.SetZIndex(Line, value);
        }
    }
}
