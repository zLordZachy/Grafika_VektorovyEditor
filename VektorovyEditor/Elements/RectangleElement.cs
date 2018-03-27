﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VektorovyEditor.Elements
{
    public class RectangleElement
    {
        public Rectangle Rectangle { get; set; }
        public Canvas Canvas { get; set; }
        public Point StartPoint { get; set; }

        public int ZIndex
        {
            get => _zIndex;
            set
            {
                _zIndex = value;
                Panel.SetZIndex(Rectangle, value);
            }
        }

        public RectangleElement(Canvas canvas, Point startPoint, Color color, double strokeThickness, DoubleCollection doubleCollection )
        {
            Canvas = canvas;
            StartPoint = startPoint;
            SolidColorBrush brush = new SolidColorBrush(color);
            Rectangle = new Rectangle
            {
                Stroke = Brushes.DarkBlue,
                StrokeThickness = strokeThickness,
                StrokeDashArray = doubleCollection,
                Fill = brush
            };
            ZIndex = 20;
            canvas.Children.Add(Rectangle);
        }

        public void DrawRectangle(Point pos)
        {
            var x = Math.Min(pos.X, StartPoint.X);
            var y = Math.Min(pos.Y, StartPoint.Y);

            var w = Math.Max(pos.X, StartPoint.X) - x;
            var h = Math.Max(pos.Y, StartPoint.Y) - y;

            Rectangle.Width = w;
            Rectangle.Height = h;

            Canvas.SetLeft(Rectangle, x);
            Canvas.SetTop(Rectangle, y);
        }

        private int _zIndex;
    }
}