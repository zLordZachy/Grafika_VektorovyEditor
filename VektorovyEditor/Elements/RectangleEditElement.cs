using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VektorovyEditor.Elements
{
    public class RectangleEditElement : RectangleElement
    {
       
        public RectangleEditElement(Canvas canvas, Point startPoint, Color fillColor, Color borderColor, double strokeThickness, DoubleCollection doubleCollection)
        : base(canvas, startPoint, fillColor, borderColor, strokeThickness, doubleCollection)
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

            Canvas.SetLeft(Rectangle, x);
            Canvas.SetTop(Rectangle, y);
            base.Draw(point);
        }

        public override void Delet()
        {
            Canvas.Children.Remove(Rectangle);
            base.Delet();
        }


        public override void Move(Point point)
        {
            var newX = (StartPoint.X + ((point.X - Rectangle.Width) - StartPoint.X));
            var newY = (StartPoint.Y + ((point.Y - Rectangle.Height) - StartPoint.Y));
            Point offset = new Point((StartPoint.X - EndPoint.X), (StartPoint.Y - EndPoint.Y));
            Top = newY - offset.Y;
            Left = newX - offset.X;

            Rectangle.SetValue(Canvas.TopProperty, Top);
            Rectangle.SetValue(Canvas.LeftProperty, Left);
            //      EndPoint = new Point{ X = Canvas.GetLeft(Rectangle) , Y = Canvas.GetTop(Rectangle) };

            //StartPoint.X = Canvas.GetLeft(Rectangle);
            //StartPoint.Y = Canvas.GetTop(Rectangle);

            //     EndPoint = new Point{X = canvasTop, Y = canvasLeft};

        }

        public override void Setstroke(double strokeThickness)
        {
            if (Rectangle == null)
                return;
            Rectangle.StrokeThickness = strokeThickness;
        }



        protected override void SetZIndex(int value)
        {
            Panel.SetZIndex(Rectangle, value);
        }
    }
}
