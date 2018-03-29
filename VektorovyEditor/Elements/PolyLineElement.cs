using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VektorovyEditor.Elements
{
    public class PolyLineElement : BaseElement
    {
        public Polyline PolyLine { get; set; }
        public PointCollection Points { get; set; }


        public PolyLineElement(Canvas canvas, Point startPoint, Color fillColor, Color borderColor, double strokeThickness, DoubleCollection doubleCollection)
        : base(canvas,fillColor,borderColor, strokeThickness, doubleCollection,startPoint)
        {
            Points = new PointCollection {StartPoint};

            PolyLine = new Polyline()
            {
                Stroke = ColorBorder,
                StrokeThickness = StrokeThickness,
                StrokeDashArray = Doush,
                Fill = ColorFill,
                Points = Points
            };

           canvas.Children.Add(PolyLine);
        }

        public override void Draw(Point point)
        {
           Points.Add(point);
           base.Draw(point);
        }

        protected override void SetZIndex(int value)
        {
            Panel.SetZIndex(PolyLine, value);
        }
    }
}
