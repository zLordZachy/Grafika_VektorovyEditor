using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VektorovyEditor.Elements
{
    public class BaseElement
    {
        public Canvas Canvas { get; set; }
        public SolidColorBrush ColorFill { get; set; }
        public SolidColorBrush ColorBorder { get; set; }
        public double StrokeThickness { get; set; }
        public DoubleCollection Doush { get; set; }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public int ZIndex
        {
            get => _zIndex;
            set
            {
                _zIndex = value;
                SetZIndex(value);
            }
        }

        public BaseElement(Canvas canvas, Color colorFill, Color colorBorder, double strokeThickness, DoubleCollection doush, Point startPoint)
        {
            Canvas = canvas;
            ColorBorder = new SolidColorBrush(colorBorder);
            ColorFill = new SolidColorBrush(colorFill);
            StrokeThickness = strokeThickness;
            Doush = doush;
            StartPoint = startPoint;
            EndPoint = startPoint;
        }

        public virtual void Draw(Point point)
        {

            EndPoint = point;
        }

        protected virtual void SetZIndex(int value)
        {
        }

        private int _zIndex;

    }
}
