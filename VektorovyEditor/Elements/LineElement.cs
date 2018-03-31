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

        public override void Delet()
        {
            Canvas.Children.Remove(Line);
            base.Delet();
        }

        public override void Move(Point point)
        {
            //var newX = (StartPoint.X + ((point.X ) - StartPoint.X));
            //var newY = (StartPoint.Y + ((point.Y ) - StartPoint.Y));

            //var newX2 = (EndPoint.X + ((point.X ) - EndPoint.X));
            //var newY2 = (EndPoint.Y + ((point.Y ) - EndPoint.Y));
            //Point offset = new Point((StartPoint.X - EndPoint.X), (StartPoint.Y - EndPoint.Y));
            //double canvasTop = newY - offset.Y;
            //double canvasLeft = newX - offset.X;
         }

        protected override void SetZIndex(int value)
        {
            Panel.SetZIndex(Line, value);
        }
    }
}
