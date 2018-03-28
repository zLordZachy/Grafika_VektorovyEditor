﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VektorovyEditor.Elements
{
    public class LineElement
    {
        public Line Line { get; set; }
        public Canvas Canvas { get; set; }
        public Point StartPoint { get; set; }

        public int ZIndex
        {
            get => _zIndex;
            set
            {
                _zIndex = value;
                Panel.SetZIndex(Line, value);
            }
        }

        public LineElement(Canvas canvas, Point startPoint, Color fillColor, Color borderColor, double strokeThickness, DoubleCollection doubleCollection)
        {
            Canvas = canvas;
            StartPoint = startPoint;
            SolidColorBrush border = new SolidColorBrush(borderColor);
            SolidColorBrush fill = new SolidColorBrush(fillColor);

            Line = new Line
            {
                Stroke = border,
                StrokeThickness = strokeThickness,
                StrokeDashArray = doubleCollection,
                Fill = fill,
                X1 = StartPoint.X,
                Y1 = StartPoint.Y,
                X2 = StartPoint.X,
                Y2 = StartPoint.Y,
        };

            ZIndex = 20;
            canvas.Children.Add(Line);
        }

        public void Draw(Point pos)
        {
            Line.X2 = pos.X;
            Line.Y2 = pos.Y;
        }

        private int _zIndex;

    }
}
