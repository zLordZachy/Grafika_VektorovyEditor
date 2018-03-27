using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Shapes;
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


        public ZCommand SetBorderColorCommand { get; set; }


        public MainViewModel()
        {
            BorderColor = Colors.BlueViolet;
            FillColor = Colors.GreenYellow;
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

        private Color _borderColor;
        private Color _fillColor;
    }
}
