using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using VektorovyEditor.Elements;
using VektorovyEditor.helpers;

namespace VektorovyEditor.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Elements property
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                OnPropertyChanged(nameof(BorderColor));
            }
        }

        public Color FillColor
        {
            get => _fillColor;
            set
            {
                _fillColor = value;
                OnPropertyChanged(nameof(BorderColor));
            }
        }

        public double StrokeThickness
        {
            get => _strokeThickness;
            set
            {
                _strokeThickness = value;
                OnPropertyChanged(nameof(StrokeThickness));
            }
        }

        #endregion

        public bool Line { get; set; }
        public bool PolyLine { get; set; }
        public bool Rectangle { get; set; }
        public bool Ellipse { get; set; }
        public bool Change { get; set; }
        public bool Delet { get; set; }
        public Canvas Canvas { get; set; }

        #region SelectedElements

        public RectangleElement SelectedRectangle { get; set; }
        public EllipseElement SelectedEllipse { get; set; }
        public LineElement SelectedLine { get; set; }
        public PolyLineElement SelectedPolyLine { get; set; }


        #endregion

        public ZCommand SetBorderColorCommand { get; set; }


        public MainViewModel(Canvas baseCanvas)
        {
            BorderColor = Colors.BlueViolet;
            FillColor = Colors.GreenYellow;
            StrokeThickness = 2;
            Canvas = baseCanvas;
            Canvas.MouseLeftButtonDown += CanvasMouseLeftButtonDown;
            Canvas.MouseLeftButtonUp += CanvasMouseLeftButtonUp;
            Canvas.MouseMove += CanvasMouseMove;
        }

        private void SetBorderColor(object obj)
        {
            
        }

        private bool CanBorder(object obj)
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Line)
            {
                SelectedLine = new LineElement(Canvas, e.GetPosition(Canvas), FillColor, BorderColor, StrokeThickness, new DoubleCollection());
                SelectedLine.Line.MouseLeftButtonDown += LineMouseButtonDown;
            }else if (PolyLine)
            {
                SelectedPolyLine = new PolyLineElement(Canvas, e.GetPosition(Canvas), FillColor, BorderColor, StrokeThickness, new DoubleCollection());
            }
            else if(Rectangle)
            {
                SelectedRectangle = new RectangleElement(Canvas, e.GetPosition(Canvas),FillColor,BorderColor,StrokeThickness, new DoubleCollection());
                SelectedRectangle.Rectangle.MouseLeftButtonDown += RectangleMouseButtonDown;
            }
            else if (Ellipse)
            {
                SelectedEllipse = new EllipseElement(Canvas, e.GetPosition(Canvas), FillColor, BorderColor, StrokeThickness, new DoubleCollection());
                SelectedEllipse.Ellipse.MouseLeftButtonDown += EllipseMouseButtonDown;
            }
            else if(Change)
            {
                
            }

        }


        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (Line)
            {
                if (SelectedLine == null)
                    return;
                SelectedLine.Draw(e.GetPosition(Canvas));
            }
            else if (PolyLine)
            {
                if (SelectedPolyLine == null)
                    return;
                SelectedPolyLine.Draw(e.GetPosition(Canvas));
            }
            else if (Rectangle)
            {
                if(SelectedRectangle == null)
                    return;
                SelectedRectangle.DrawRectangle(e.GetPosition(Canvas));
            }
            else if (Ellipse)
            {
                if (SelectedEllipse == null)
                    return;
                SelectedEllipse.Draw(e.GetPosition(Canvas));
            }
            else if (Change)
            {

            }
        }

        private void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Line)
            {
                SelectedLine = null;
            }
            else if (PolyLine)
            {
                SelectedPolyLine = null;
            }
            else if (Rectangle)
            {
                SelectedRectangle = null;
            }
            else if (Ellipse)
            {
                SelectedEllipse = null;
            }
            else if (Change)
            {

            }
        }

        private void LineMouseButtonDown(object sende, MouseButtonEventArgs e)
        {

        }

        private void RectangleMouseButtonDown(object sende, MouseButtonEventArgs e)
        {

        }

        private void EllipseMouseButtonDown(object sende, MouseButtonEventArgs e)
        {

        }

        private Color _borderColor;
        private Color _fillColor;
        private double _strokeThickness;
    }
}
