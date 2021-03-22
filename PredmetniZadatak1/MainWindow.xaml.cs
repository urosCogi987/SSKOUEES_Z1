using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PredmetniZadatak1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Point> polygonPoints;
        public UndoRedoClear undoRedoClearObject;
        public bool prevAction = false;

        private enum MyShape
        {
            Ellipse, Rectangle, Polygon, Image
        };

        private MyShape currentShape = MyShape.Ellipse;        

        public MainWindow()
        {
            InitializeComponent();
            polygonPoints = new List<Point>();
            UndoRedoClear undoRedoClearO = new UndoRedoClear();
            undoRedoClearObject = undoRedoClearO;
        }        

       

        public void object_clicked(object sender, EventArgs e)
        {
            string objectCalled = sender.ToString().Split('.')[3];
            prevAction = true;

            if (objectCalled.Trim().ToLower() == "ellipse")
            {
                Ellipse ellipse = sender as Ellipse;
                ShapeSpecification window = new ShapeSpecification("Ellipse", new Point(), null, true, ellipse);
                window.ShowDialog();
                return;
                
            }
            else if (objectCalled.Trim().ToLower() == "rectangle")
            {
                Rectangle rectangle = sender as Rectangle;
                ShapeSpecification window = new ShapeSpecification("Rectangle", new Point(), null, true, rectangle);
                window.ShowDialog();
                return;
                
            }
            else if (objectCalled.Trim().ToLower() == "polygon")
            {
                Polygon polygon = sender as Polygon;
                ShapeSpecification window = new ShapeSpecification("Polygon", new Point(), null, true, polygon);
                window.ShowDialog();
                return;
            }
            else
            {
                Image image = sender as Image;
                ShapeSpecification window = new ShapeSpecification("Image", new Point(), null, true, null, image);
                window.ShowDialog();
                return;
            }


        }

        private void MyCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {            
            if (prevAction == true)
            {
                prevAction = false;
                return;
            }

            // Draw the correct shape
            switch (currentShape)
            {
                case MyShape.Ellipse:
                    DrawEllipse();
                    break;

                case MyShape.Rectangle:
                    DrawRectangle();
                    break;

                case MyShape.Polygon:
                    if (polygonPoints.Count >= 3)
                        DrawPolygon();
                    break;

                case MyShape.Image:
                    InputImage();
                    break;

                default:
                    return;
            }
        }

        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            currentShape = MyShape.Ellipse;

            EllipseButton.Background = Brushes.LightBlue;
            RectangleButton.Background = Brushes.CornflowerBlue;
            PolygonButton.Background = Brushes.CornflowerBlue;
            ImageButton.Background = Brushes.CornflowerBlue;
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            currentShape = MyShape.Rectangle;

            EllipseButton.Background = Brushes.CornflowerBlue;
            RectangleButton.Background = Brushes.LightBlue;
            PolygonButton.Background = Brushes.CornflowerBlue;
            ImageButton.Background = Brushes.CornflowerBlue;
        }

        private void PolygonButton_Click(object sender, RoutedEventArgs e)
        {
            currentShape = MyShape.Polygon;

            EllipseButton.Background = Brushes.CornflowerBlue;
            RectangleButton.Background = Brushes.CornflowerBlue;
            PolygonButton.Background = Brushes.LightBlue;
            ImageButton.Background = Brushes.CornflowerBlue;
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            currentShape = MyShape.Image;

            EllipseButton.Background = Brushes.CornflowerBlue;
            RectangleButton.Background = Brushes.CornflowerBlue;
            PolygonButton.Background = Brushes.CornflowerBlue;
            ImageButton.Background = Brushes.LightBlue;
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            if (undoRedoClearObject.CheckIfUndoEmpty())
            {
                if (polygonPoints.Count > 0)
                {
                    ClearPolygonPoints();
                    return;
                }

                UIElement canvasObj = undoRedoClearObject.RemoveUndoStackItem();
                MyCanvas.Children.Remove(canvasObj);
                undoRedoClearObject.AddRedoStackItem(canvasObj);                
            }
            else if (polygonPoints.Count > 0)
            {
                ClearPolygonPoints();
            }
            else
            {
                MessageBox.Show("Nothing more to Undo.");
            }
        }

        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            if (undoRedoClearObject.CheckIfRedoEmpty())
            {
                UIElement canvasObj = undoRedoClearObject.RemoveRedoStackItem();
                MyCanvas.Children.Add(canvasObj);
                undoRedoClearObject.AddUndoStackItem(canvasObj);                
            }
            else
            {
                MessageBox.Show("Nothing to Redo.");
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {            
            undoRedoClearObject.Clear();
            MyCanvas.Children.Clear();
        }

        private void DrawEllipse()
        {            
            var cursorPosition = Mouse.GetPosition(MyCanvas);
            Point startingPosition = new Point(cursorPosition.X, cursorPosition.Y);
            ShapeSpecification shape = new ShapeSpecification("Ellipse", startingPosition);
            shape.ShowDialog();            
        }

        private void DrawRectangle()
        {
            var cursorPosition = Mouse.GetPosition(MyCanvas);
            Point startingPosition = new Point(cursorPosition.X, cursorPosition.Y);
            ShapeSpecification shape = new ShapeSpecification("Rectangle", startingPosition);
            shape.ShowDialog();
        }

        private void DrawPolygon()
        {
            var cursorPosition = Mouse.GetPosition(MyCanvas);
            Point startingPosition = new Point(cursorPosition.X, cursorPosition.Y);
            ShapeSpecification shape = new ShapeSpecification("Polygon", startingPosition, polygonPoints);
            shape.ShowDialog();
        }

        private void InputImage()
        {
            var cursorPosition = Mouse.GetPosition(MyCanvas);
            Point startingPosition = new Point(cursorPosition.X, cursorPosition.Y);
            ShapeSpecification image = new ShapeSpecification("Image", startingPosition);
            image.ShowDialog();
        }

        private void MyCanvas_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var cursorPosition = Mouse.GetPosition(MyCanvas);
            Point startingPosition = new Point(cursorPosition.X, cursorPosition.Y);
            Point pointPosition = e.GetPosition((Canvas)sender);

            if (currentShape == MyShape.Polygon)
            {
                Ellipse dot = new Ellipse();
                dot.Stroke = new SolidColorBrush(Colors.Black);
                dot.StrokeThickness = 3;
                dot.Height = 3;
                dot.Width = 3;
                dot.Fill = new SolidColorBrush(Colors.Black);
                dot.Opacity = 0.7;

                if (polygonPoints.Count > 0)
                {
                    Line line = new Line() { X1 = polygonPoints[polygonPoints.Count - 1].X, Y1 = polygonPoints[polygonPoints.Count - 1].Y,
                        X2 = pointPosition.X, Y2 = pointPosition.Y, Stroke = Brushes.Black };
                    line.Opacity = 0.7;
                    MyCanvas.Children.Add(line);
                    //undoRedoClearObject.AddUndoStackItem(line);
                }
                
                MyCanvas.Children.Add(dot);
                //undoRedoClearObject.AddUndoStackItem(dot);

                Canvas.SetLeft(dot, pointPosition.X);
                Canvas.SetTop(dot, pointPosition.Y);

                polygonPoints.Add(pointPosition);
                
            }
        }        

        private void ClearPolygonPoints()
        {
            if (polygonPoints.Count > 0)
            MyCanvas.Children.RemoveRange(MyCanvas.Children.Count - (2 * polygonPoints.Count - 1), 2 * polygonPoints.Count - 1);
            polygonPoints.Clear();
        }
    }
}
