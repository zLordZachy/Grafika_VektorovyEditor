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

        public override void Delet()
        {
            Canvas.Children.Remove(Ellipse);
            base.Delet();
        }

        public override void Move(Point point)
        {
            var newX = (StartPoint.X + ((point.X - Ellipse.Width - Ellipse.Width / 2) - StartPoint.X));
            var newY = (StartPoint.Y + ((point.Y - Ellipse.Height - Ellipse.Height / 2) - StartPoint.Y));
            Point offset = new Point((StartPoint.X - EndPoint.X), (StartPoint.Y - EndPoint.Y));
            double canvasTop = newY - offset.Y;
            double canvasLeft = newX - offset.X;

            Top = canvasTop;
            Left = canvasLeft;

            Ellipse.SetValue(Canvas.TopProperty, canvasTop);
            Ellipse.SetValue(Canvas.LeftProperty, canvasLeft);
        }

        public override void SetHeight(double velikost)
        {
            if (velikost < 1)
                return;
            Ellipse.Height = velikost;
            EndPoint = new Point { X = EndPoint.X, Y = StartPoint.Y + velikost };
        }

        public override void SetWidth(double velikost)
        {
            if (velikost < 1)
                return;
            Ellipse.Width = velikost;
            EndPoint = new Point { X = StartPoint.X + velikost, Y = EndPoint.Y };
        }

        public override void SetTop(double velikost)
        {
            if (velikost < 1)
                return;
            Ellipse.SetValue(Canvas.TopProperty, velikost);
            StartPoint = new Point(StartPoint.X, velikost);
            base.SetTop(velikost);
        }

        public override void SetLeft(double velikost)
        {
            if (velikost < 1)
                return;
            Ellipse.SetValue(Canvas.LeftProperty, velikost);
            base.SetLeft(velikost);
        }

        protected override void SetZIndex(int value)
        {
            Panel.SetZIndex(Ellipse, value);
        }
    }
}
