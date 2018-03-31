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
        private Point OriginPoint { get; set; }

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
            OriginPoint = startPoint;
            canvas.Children.Add(Rectangle);
        }

        public override void Draw(Point point)
        {
            var x = Math.Min(point.X, OriginPoint.X);
            var y = Math.Min(point.Y, OriginPoint.Y);

            var w = Math.Max(point.X, OriginPoint.X) - x;
            var h = Math.Max(point.Y, OriginPoint.Y) - y;

            Rectangle.Width = w;
            Rectangle.Height = h;
                        
            Canvas.SetLeft(Rectangle, x);
            Canvas.SetTop(Rectangle, y);

            StartPoint = new Point{X= x, Y =y};
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
        }

        public override void SetHeight(double velikost)
        {
            if (velikost < 1)
                return;
            Rectangle.Height = velikost;
            EndPoint = new Point { X = EndPoint.X , Y = StartPoint.Y + velikost };
        }

        public override void SetWidth(double velikost)
        {
            if(velikost<1)
                return;
            Rectangle.Width = velikost;
            EndPoint = new Point{X = StartPoint.X+ velikost, Y =  EndPoint.Y};
        }

        public override void SetTop(double velikost)
        {
            if (velikost < 1)
                return;
            Rectangle.SetValue(Canvas.TopProperty, velikost);
            base.SetTop(velikost);
        }

        public override void SetLeft(double velikost)
        {
            if (velikost < 1)
                return;
            Rectangle.SetValue(Canvas.LeftProperty, velikost);
            base.SetLeft(velikost);
        }



        protected override void SetZIndex(int value)
        {
            Panel.SetZIndex(Rectangle, value);
        }
    }
}
