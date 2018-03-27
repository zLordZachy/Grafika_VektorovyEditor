using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using VektorovyEditor.Elements;
using VektorovyEditor.helpers;
using Xceed.Wpf.Toolkit;

namespace VektorovyEditor.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
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

        public bool Line { get; set; }
        public bool Rectangle { get; set; }
        public bool Ellipse { get; set; }
        public bool Change { get; set; }
        public bool Delet { get; set; }
        public Canvas Canvas { get; set; }

        #region SelectedElements

        public RectangleElement SelectedRectangle { get; set; }

        #endregion

        public ZCommand SetBorderColorCommand { get; set; }


        public MainViewModel(Canvas baseCanvas)
        {
            BorderColor = Colors.BlueViolet;
            FillColor = Colors.GreenYellow;
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

            }
            else if(Rectangle)
            {
                SelectedRectangle = new RectangleElement(Canvas, e.GetPosition(Canvas),FillColor,2, new DoubleCollection());
            }else if (Ellipse)
            {

            }
            else if(Change)
            {
                
            }

        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (Line)
            {

            }
            else if (Rectangle)
            {
                if(SelectedRectangle == null)
                    return;
                SelectedRectangle.DrawRectangle(e.GetPosition(Canvas));
            }
            else if (Ellipse)
            {

            }
            else if (Change)
            {

            }
        }

        private void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Line)
            {

            }
            else if (Rectangle)
            {
                SelectedRectangle = null;
            }
            else if (Ellipse)
            {

            }
            else if (Change)
            {

            }
        }

        private Color _borderColor;
        private Color _fillColor;
    }
}
