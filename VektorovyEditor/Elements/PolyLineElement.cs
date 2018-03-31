using System.Linq;
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
        public override void Delet()
        {
            Canvas.Children.Remove(PolyLine);
            base.Delet();
        }

        public override void Edit()
        {
            Point min = new Point { X = Points.Min(x => x.X), Y = Points.Min(y => y.Y) };
            RectangleEditBase =
                new RectangleElement(Canvas, min, Colors.Transparent, Colors.Black, 3,
                    new DoubleCollection {1, 1, 1, 1, 1, 1}) {Rectangle = {Fill = null}};

            Point hightest = new Point{X = Points.Max(x=>x.X), Y = Points.Max(y => y.Y) };

            RectangleEditBase.Draw(hightest);
            RectangleEditBase.ZIndex = 100;
        }

        protected override void SetZIndex(int value)
        {
            Panel.SetZIndex(PolyLine, value);
        }
    }
}
