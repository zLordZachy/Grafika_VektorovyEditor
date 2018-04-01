using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VektorovyEditor.Elements
{
    public class PatternBrushes
    {

        public static DrawingBrush ChessBrush()
        {
            DrawingBrush myBrush = new DrawingBrush();

            GeometryDrawing backgroundSquare =
                new GeometryDrawing(
                    System.Windows.Media.Brushes.White,
                    null,
                    new RectangleGeometry(new Rect(0, 0, 100, 100)));

            GeometryGroup aGeometryGroup = new GeometryGroup();
            aGeometryGroup.Children.Add(new RectangleGeometry(new Rect(0, 0, 50, 50)));
            aGeometryGroup.Children.Add(new RectangleGeometry(new Rect(50, 50, 50, 50)));

            LinearGradientBrush checkerBrush = new LinearGradientBrush();
            checkerBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.0));
            checkerBrush.GradientStops.Add(new GradientStop(Colors.Gray, 1.0));

            GeometryDrawing checkers = new GeometryDrawing(checkerBrush, null, aGeometryGroup);

            DrawingGroup checkersDrawingGroup = new DrawingGroup();
            checkersDrawingGroup.Children.Add(backgroundSquare);
            checkersDrawingGroup.Children.Add(checkers);

            myBrush.Drawing = checkersDrawingGroup;
            myBrush.Viewport = new Rect(0, 0, 0.25, 0.25);
            myBrush.TileMode = TileMode.Tile;
            return myBrush;
        }

        public static DrawingBrush BetaBrush()
        {
            // Create a background recntangle

            Rectangle chessBoard = new Rectangle();

            chessBoard.Width = 300;

            chessBoard.Height = 300;

            // Create a DrawingBrush

            DrawingBrush blackBrush = new DrawingBrush();

            // Create a Geometry with white background

            GeometryDrawing backgroundSquare =

                new GeometryDrawing(

                    Brushes.Blue,

                    null,

                    new RectangleGeometry(new Rect(0, 0, 400, 400)));

            // Create a GeometryGroup that will be added to Geometry

            GeometryGroup gGroup = new GeometryGroup();

            gGroup.Children.Add(new EllipseGeometry(new Rect(0, 0, 200, 200)));

            gGroup.Children.Add(new RectangleGeometry(new Rect(200, 200, 200, 200)));

            // Create a GeomertyDrawing

            GeometryDrawing checkers = new GeometryDrawing(new SolidColorBrush(Colors.Chartreuse), null, gGroup);


            DrawingGroup checkersDrawingGroup = new DrawingGroup();

            checkersDrawingGroup.Children.Add(backgroundSquare);

            checkersDrawingGroup.Children.Add(checkers);



            blackBrush.Drawing = checkersDrawingGroup;



            // Set Viewport and TimeMode

            blackBrush.Viewport = new Rect(0, 0, 0.25, 0.25);

            blackBrush.TileMode = TileMode.Tile;



            // Fill rectangle with a DrawingBrush

            chessBoard.Fill = blackBrush;

            
            return blackBrush;
        }


        public static DrawingBrush SomeBrush()
        {
            // Create a background recntangle

            Rectangle chessBoard = new Rectangle();

            chessBoard.Width = 300;

            chessBoard.Height = 300;

            // Create a DrawingBrush

            DrawingBrush blackBrush = new DrawingBrush();

            // Create a Geometry with white background

            GeometryDrawing backgroundSquare =

                new GeometryDrawing(

                    Brushes.DimGray,

                    null,

                    new RectangleGeometry(new Rect(0, 0, 400, 400)));

            // Create a GeometryGroup that will be added to Geometry

            GeometryGroup gGroup = new GeometryGroup();

            gGroup.Children.Add(new EllipseGeometry(new Rect(0, 0, 200, 200)));
            gGroup.Children.Add(new LineGeometry(new Point(10,10),new Point(100,50)));

            // Create a GeomertyDrawing

            GeometryDrawing checkers = new GeometryDrawing(new SolidColorBrush(Colors.Yellow), null, gGroup);


            DrawingGroup checkersDrawingGroup = new DrawingGroup();

            checkersDrawingGroup.Children.Add(backgroundSquare);

            checkersDrawingGroup.Children.Add(checkers);



            blackBrush.Drawing = checkersDrawingGroup;



            // Set Viewport and TimeMode

            blackBrush.Viewport = new Rect(0, 0, 0.25, 0.25);

            blackBrush.TileMode = TileMode.Tile;



            // Fill rectangle with a DrawingBrush

            chessBoard.Fill = blackBrush;


            return blackBrush;
        }
    }
}
