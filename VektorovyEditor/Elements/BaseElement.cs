using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VektorovyEditor.Elements
{
    public class BaseElement
    {
        public Canvas Canvas { get; set; }
        public SolidColorBrush ColorFill { get; set; }
        public SolidColorBrush ColorBorder { get; set; }
        public double StrokeThickness { get; set; }
        public DoubleCollection Doush { get; set; }

        public double? Left { get; set; }
        public double? Top { get; set; }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public RectangleElement RectangleEditBase { get; set; }

        private RectangleElement Rectangle1 { get; set; }
        private RectangleElement Rectangle2 { get; set; }
        private RectangleElement Rectangle3 { get; set; }
        private RectangleElement Rectangle4 { get; set; }
        private RectangleElement Rectangle5 { get; set; }
        private RectangleElement Rectangle6 { get; set; }
        private RectangleElement Rectangle7 { get; set; }
        private RectangleElement Rectangle8 { get; set; }


        private bool Is2Editing { get; set; }

        private bool Is4Editing { get; set; }
        public bool Is6Editing { get; set; }
        private bool Is8Editing { get; set; }


        private Point OriginPoint { get; set; }



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
            Debug.WriteLine($"x: {point.X} y: {point.Y}");
        }

        public virtual void Edit()
        {
            RectangleEditBase =
                new RectangleElement(Canvas, StartPoint, Colors.Transparent, Colors.Black, 3, new DoubleCollection{1,1,1,1,1,1});

            RectangleEditBase.Rectangle.Fill = null;
            RectangleEditBase.Draw(EndPoint);
            RectangleEditBase.SetZIndex(100);

            if(Left != null)
                RectangleEditBase.Rectangle.SetValue(Canvas.LeftProperty, Left);
            if (Top != null)
                RectangleEditBase.Rectangle.SetValue(Canvas.TopProperty, Top);
            if (Top != null && Left != null)
            {
                RectangleEditBase.StartPoint = new Point(Left.Value, Top.Value);
            }


            Rectangle1 = new RectangleElement(Canvas, new Point{X= RectangleEditBase.StartPoint.X-5, Y = RectangleEditBase.StartPoint.Y-5}, Colors.Black, Colors.Black, 3, new DoubleCollection());
            Rectangle1.Draw(new Point{X = RectangleEditBase.StartPoint.X + 10, Y = RectangleEditBase.StartPoint.Y +10});

            var RectEditWidth = RectangleEditBase.Rectangle.Width;
            var RectEditHeight = RectangleEditBase.Rectangle.Height;

            Rectangle2 = new RectangleElement(Canvas, new Point { X = RectangleEditBase.StartPoint.X + RectEditWidth/2 - 5, Y = RectangleEditBase.StartPoint.Y - 5 }, Colors.Black, Colors.Black, 3, new DoubleCollection());
            Rectangle2.Draw(new Point { X = Rectangle2.StartPoint.X + 15, Y = RectangleEditBase.StartPoint.Y + 10 });

            Rectangle3 = new RectangleElement(Canvas, new Point { X = RectangleEditBase.StartPoint.X + RectEditWidth - 10, Y = RectangleEditBase.StartPoint.Y - 5 }, Colors.Black, Colors.Black, 3, new DoubleCollection());
            Rectangle3.Draw(new Point { X = Rectangle3.StartPoint.X + 15, Y = RectangleEditBase.StartPoint.Y+ 10 });

            Rectangle4 = new RectangleElement(Canvas, new Point { X = RectangleEditBase.StartPoint.X + RectEditWidth - 10, Y = RectangleEditBase.StartPoint.Y+RectEditHeight/2 - 5 }, Colors.Black, Colors.Black, 3, new DoubleCollection());
            Rectangle4.Draw(new Point { X = Rectangle4.StartPoint.X + 15, Y = RectangleEditBase.StartPoint.Y + RectEditHeight / 2 + 10 });

            Rectangle5 = new RectangleElement(Canvas, new Point { X = RectangleEditBase.StartPoint.X + RectEditWidth - 10, Y = RectangleEditBase.StartPoint.Y + RectEditHeight  - 10 }, Colors.Black, Colors.Black, 3, new DoubleCollection());
            Rectangle5.Draw(new Point { X = Rectangle5.StartPoint.X + 15, Y = RectangleEditBase.StartPoint.Y + RectEditHeight  + 5 });

            Rectangle6 = new RectangleElement(Canvas, new Point { X = RectangleEditBase.StartPoint.X + RectEditWidth / 2 - 5, Y = RectangleEditBase.StartPoint.Y + RectEditHeight - 10 }, Colors.Black, Colors.Black, 3, new DoubleCollection());
            Rectangle6.Draw(new Point { X = Rectangle6.StartPoint.X + 15, Y = RectangleEditBase.StartPoint.Y + RectEditHeight + 5 });

            Rectangle7 = new RectangleElement(Canvas, new Point { X = RectangleEditBase.StartPoint.X + - 5, Y = RectangleEditBase.StartPoint.Y + RectEditHeight - 10 }, Colors.Black, Colors.Black, 3, new DoubleCollection());
            Rectangle7.Draw(new Point { X = Rectangle7.StartPoint.X + 15, Y = RectangleEditBase.StartPoint.Y + RectEditHeight + 5 });

            Rectangle8 = new RectangleElement(Canvas, new Point { X = RectangleEditBase.StartPoint.X + -5, Y = RectangleEditBase.StartPoint.Y + RectEditHeight / 2 - 5 }, Colors.Black, Colors.Black, 3, new DoubleCollection());
            Rectangle8.Draw(new Point { X = Rectangle8.StartPoint.X + 15, Y = RectangleEditBase.StartPoint.Y + RectEditHeight / 2 + 10 });

            Rectangle8.Rectangle.MouseLeftButtonDown += LeftButtonDown;
            Rectangle4.Rectangle.MouseLeftButtonDown += LeftButtonDown;
            Rectangle6.Rectangle.MouseLeftButtonDown += LeftButtonDown;
            Rectangle2.Rectangle.MouseLeftButtonDown += LeftButtonDown;

            Canvas.MouseLeftButtonUp += LeftButtonUp;
            Canvas.MouseMove += MouseMove;
        }

        private void LeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Is2Editing = false;
            Is4Editing = false;
            Is6Editing = false;
            Is8Editing = false;

        }


        private void MouseMove(object sender, MouseEventArgs e)
        {
                if(RectangleEditBase==null)
                    return;;


                var top = Canvas.GetTop(RectangleEditBase.Rectangle);
                var left = Canvas.GetLeft(RectangleEditBase.Rectangle);

        
    
                var width = RectangleEditBase.Rectangle.ActualWidth;
                var height = RectangleEditBase.Rectangle.ActualHeight;


                if (Is2Editing)
                {
                    double disc = e.GetPosition(Canvas).Y - OriginPoint.Y;
                    SetTop(top + disc);
                   SetHeight(height - disc);

                    //Canvas.SetTop(Rectangle1.Rectangle, top + disc);
                    //Canvas.SetTop(Rectangle2.Rectangle, top + disc);
                    //Canvas.SetTop(Rectangle3.Rectangle, top + disc);
                     //   Canvas.SetTop(RectangleEditBase.Rectangle, top + disc);
                   //   RectangleEditBase.Rectangle.Height = top - disc;
                }
                else if(Is4Editing)
                {
                    double disc = e.GetPosition(Canvas).X - OriginPoint.X;
                    SetWidth(width + disc);
                }else if (Is6Editing)
                {
                    double disc = e.GetPosition(Canvas).Y - OriginPoint.Y;
                    SetHeight(height + disc);
                }
                else if (Is8Editing)
                {
                    double disc = e.GetPosition(Canvas).X - OriginPoint.X;
                    SetLeft(left + disc);
                    SetWidth(width - disc);
                }
        }



        public virtual void SetHeight(double velikost)
        {
        }

        public virtual void SetWidth(double velikost)
        {
        }

        public virtual void SetTop(double velikost)
        {
            Top = velikost;
            StartPoint = new Point(StartPoint.X, velikost);
        }

        public virtual void SetLeft(double velikost)
        {
            Left = velikost;
            StartPoint = new Point(velikost, StartPoint.Y);
        }

        private void LeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangele = sender as Rectangle;

            OriginPoint = e.GetPosition(Canvas);
            if (Rectangle2.Rectangle.Equals(rectangele))
            {
                Is2Editing = true;
            }
            else if (Rectangle4.Rectangle.Equals(rectangele))
            {
                Is4Editing = true;
            }
            else if(Rectangle6.Rectangle.Equals(rectangele))
            {
                Is6Editing = true;
            }
            else if (Rectangle8.Rectangle.Equals(rectangele))
            {
                Is8Editing = true;
            }
        }

       

        public virtual void EndEdit()
        {
            if (RectangleEditBase != null)
            {
                Canvas.Children.Remove(RectangleEditBase.Rectangle);
                RectangleEditBase = null;

                Canvas.Children.Remove(Rectangle1.Rectangle);
                Rectangle1 = null;
                Canvas.Children.Remove(Rectangle2.Rectangle);
                Rectangle2 = null;
                Canvas.Children.Remove(Rectangle3.Rectangle);
                Rectangle3 = null;
                Canvas.Children.Remove(Rectangle4.Rectangle);
                Rectangle4 = null;
                Canvas.Children.Remove(Rectangle5.Rectangle);
                Rectangle5 = null;
                Canvas.Children.Remove(Rectangle6.Rectangle);
                Rectangle6 = null;
                Canvas.Children.Remove(Rectangle7.Rectangle);
                Rectangle7 = null;
                Canvas.Children.Remove(Rectangle8.Rectangle);
                Rectangle8 = null;

            }
        }

        public virtual void Move(Point point)
        {

        }

        protected virtual void SetZIndex(int value)
        {
        }

        public virtual void Delet()
        {
            if(RectangleEditBase != null)
                EndEdit();
        }

        private int _zIndex;

    }
}
