using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VektorovyEditor.Elements
{
    public class PolyLineElement
    {
        public Polyline PolyLine { get; set; }
        public Canvas Canvas { get; set; }
        public Point StartPoint { get; set; }
        public PointCollection Points { get; set; }

        public int ZIndex
        {
            get => _zIndex;
            set
            {
                _zIndex = value;
                Panel.SetZIndex(PolyLine, value);
            }
        }

        public PolyLineElement(Canvas canvas, Point startPoint, Color fillColor, Color borderColor, double strokeThickness, DoubleCollection doubleCollection)
        {
            Canvas = canvas;
            StartPoint = startPoint;
            SolidColorBrush border = new SolidColorBrush(borderColor);
            SolidColorBrush fill = new SolidColorBrush(fillColor);
            Points = new PointCollection();
            Points.Add(startPoint);

            PolyLine = new Polyline()
            {
                Stroke = border,
                StrokeThickness = strokeThickness,
                StrokeDashArray = doubleCollection,
                Fill = fill,
                Points = Points
            };

            ZIndex = 20;
            canvas.Children.Add(PolyLine);
        }

        public void Draw(Point point)
        {
           Points.Add(point);
        }

        private int _zIndex;

    }
}
