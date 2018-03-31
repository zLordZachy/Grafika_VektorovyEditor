using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
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
     //   public bool Delet { get; set; }
        public Canvas Canvas { get; set; }

        #region SelectedElements

        public RectangleElement SelectedRectangle { get; set; }
        public EllipseElement SelectedEllipse { get; set; }
        public LineElement SelectedLine { get; set; }
        public PolyLineElement SelectedPolyLine { get; set; }

        public bool IsMovingElement { get; set; }


        public IList<BaseElement> Elements { get; set; }

        public BaseElement EditedElement
        {
            get => _editedElement;
            set
            {
                _editedElement = value;
                DeleteElementCommand.ChangeCanExecute();
            }
        }

        #endregion

        public ZCommand SetBorderColorCommand { get; set; }
        public ZCommand DeleteElementCommand { get; set; }


        public MainViewModel(Canvas baseCanvas)
        {
            BorderColor = Colors.BlueViolet;
            FillColor = Colors.GreenYellow;
            Elements = new List<BaseElement>();
            StrokeThickness = 2;
            Canvas = baseCanvas;
            Canvas.MouseLeftButtonDown += CanvasMouseLeftButtonDown;
            Canvas.MouseLeftButtonUp += CanvasMouseLeftButtonUp;
            Canvas.MouseMove += CanvasMouseMove;

            DeleteElementCommand = new ZCommand(CanDelete, Delet);
        }

        private void Delet(object obj)
        {
            if(EditedElement == null)
                return;

            Elements.Remove(EditedElement);
            EditedElement.Delet();
            EditedElement = null;
        }

        private bool CanDelete(object obj)
        {
            return EditedElement != null;
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
            if(e.ClickCount!=1)
                return;

            if (Line)
            {
                SelectedLine = new LineElement(Canvas, e.GetPosition(Canvas), FillColor, BorderColor, StrokeThickness, new DoubleCollection());
                SelectedLine.Line.MouseLeftButtonDown += LineMouseButtonDown;
                Elements.Add(SelectedLine);
            }else if (PolyLine)
            {
                SelectedPolyLine = new PolyLineElement(Canvas, e.GetPosition(Canvas), FillColor, BorderColor, StrokeThickness, new DoubleCollection());
                SelectedPolyLine.PolyLine.MouseLeftButtonDown += PolyLineMouseButtonDown;
                Elements.Add(SelectedPolyLine);
            }
            else if(Rectangle)
            {
                SelectedRectangle = new RectangleElement(Canvas, e.GetPosition(Canvas),FillColor,BorderColor,StrokeThickness, new DoubleCollection());
                SelectedRectangle.Rectangle.MouseLeftButtonDown += RectangleMouseButtonDown;
                SelectedRectangle.Rectangle.MouseLeftButtonUp += RectangleMouseButtonUp;
                Elements.Add(SelectedRectangle);

            }
            else if (Ellipse)
            {
                SelectedEllipse = new EllipseElement(Canvas, e.GetPosition(Canvas), FillColor, BorderColor, StrokeThickness, new DoubleCollection());
                SelectedEllipse.Ellipse.MouseLeftButtonDown += EllipseMouseButtonDown;
                Elements.Add(SelectedEllipse);
            }
            else if(Change)
            {
                
            }

        }

        private void RectangleMouseButtonUp(object sender, MouseButtonEventArgs e)
        {
           
            IsMovingElement = false;

        }


        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (!IsMovingElement)
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
                    if (SelectedRectangle == null)
                        return;
                    SelectedRectangle.Draw(e.GetPosition(Canvas));
                }
                else if (Ellipse)
                {
                    if (SelectedEllipse == null)
                        return;
                    SelectedEllipse.Draw(e.GetPosition(Canvas));
                }
            }
            else
            {
                EditedElement?.Move(e.GetPosition(Canvas));
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


            if (EditedElement != null)
            {
                EditedElement.EndEdit();
                EditedElement.Edit();

                IsMovingElement = false;
            }
           
        }

        private void LineMouseButtonDown(object sende, MouseButtonEventArgs e)
        {
            var editline = Elements.Where(x => x.GetType() == typeof(LineElement)).ToList();
            LineElement editeLineElement = (LineElement)editline.FirstOrDefault(x => Equals(((LineElement)x).Line, sende as Line));

            if (e.ClickCount == 2)
            {
              
                if (editeLineElement == null)
                    return;

                SetEdite(editeLineElement);
            }
            else
            {
                if (EditedElement == (editeLineElement))
                {
                    IsMovingElement = true;
                }
            }
        }

        private void PolyLineMouseButtonDown(object sender, MouseButtonEventArgs e)
        {

            var editPolyline = Elements.Where(x => x.GetType() == typeof(PolyLineElement)).ToList();
            PolyLineElement editePolyLineElement = (PolyLineElement)editPolyline.FirstOrDefault(x => Equals(((PolyLineElement)x).PolyLine, sender as Polyline));

            if (e.ClickCount == 2)
            {
                if (editePolyLineElement == null)
                    return;

                SetEdite(editePolyLineElement);
            }
            else
            {
                if (EditedElement == (editePolyLineElement))
                {
                    IsMovingElement = true;
                }
            }
        }


        private void RectangleMouseButtonDown(object sende, MouseButtonEventArgs e)
        {
            if(!(sende is Rectangle rectangle))
                return;

            var editRectangle = Elements.Where(x => x.GetType() == typeof(RectangleElement)).ToList();
            RectangleElement editeRectangleElement = (RectangleElement)editRectangle.FirstOrDefault(x => Equals(((RectangleElement)x).Rectangle, rectangle));

            if (e.ClickCount == 2)
            {
                if (editeRectangleElement == null)
                    return;

                SetEdite(editeRectangleElement);
            }
            else
            {
                if (EditedElement ==(editeRectangleElement))
                {
                    IsMovingElement = true;
                }
            }
        }


        private void EllipseMouseButtonDown(object sende, MouseButtonEventArgs e)
        {
            var editEllipse = Elements.Where(x => x.GetType() == typeof(EllipseElement)).ToList();
            EllipseElement editeEllipseElement = (EllipseElement)editEllipse.FirstOrDefault(x => Equals(((EllipseElement)x).Ellipse, sende as Ellipse));

            if (e.ClickCount == 2)
            {
                if(editeEllipseElement== null)
                    return;

                SetEdite(editeEllipseElement);
            }
            else
            {
                if (EditedElement == (editeEllipseElement))
                {
                    IsMovingElement = true;
                }
            }
        }

        private void SetEdite(BaseElement editeLineElement)
        {
            if (editeLineElement == null)
                return;

            if (EditedElement != null && EditedElement.Equals(editeLineElement))
            {
                editeLineElement.EndEdit();
                EditedElement = null;
            }
            else
            {
                EditedElement?.EndEdit();

                editeLineElement.Edit();
                EditedElement = editeLineElement;
            }
        }

        private Color _borderColor;
        private Color _fillColor;
        private double _strokeThickness;
        private BaseElement _editedElement;
    }
}
