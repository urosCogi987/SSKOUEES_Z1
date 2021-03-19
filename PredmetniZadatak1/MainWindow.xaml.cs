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

        private enum MyShape
        {
            Ellipse, Rectangle, Polygon
        };

        private MyShape currentShape = MyShape.Ellipse;
        Point clickPoint;

        public MainWindow()
        {
            InitializeComponent();
            polygonPoints = new List<Point>();
        }

        //private void AddOrRemoveItem(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.OriginalSource is Rectangle)
        //    {
        //        Rectangle activeRectangle = (Rectangle)e.OriginalSource;

        //        MyCanvas.Children.Remove(activeRectangle);
        //    }
        //    else
        //    {
        //        customColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));

        //        Rectangle newRectangle = new Rectangle
        //        {
        //            Width = 50,
        //            Height = 50,
        //            Fill = customColor,
        //            StrokeThickness = 3,
        //            Stroke = Brushes.Black
        //        };

        //        Canvas.SetLeft(newRectangle, Mouse.GetPosition(MyCanvas).X);
        //        Canvas.SetTop(newRectangle, Mouse.GetPosition(MyCanvas).Y);

        //        MyCanvas.Children.Add(newRectangle);
        //    }
        //}

        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickPoint = e.GetPosition(this);
        }

        private void MyCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
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
                    DrawPolygon();
                    break;

                default:
                    return;
            }
        }

        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            currentShape = MyShape.Ellipse;            
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            currentShape = MyShape.Rectangle;            
        }

        private void PolygonButton_Click(object sender, RoutedEventArgs e)
        {
            currentShape = MyShape.Polygon;            
        }

        private void DrawEllipse()
        {            
            var cursorPosition = Mouse.GetPosition(MyCanvas);
            Point startingPosition = new Point(cursorPosition.X, cursorPosition.Y);
            ShapeSpecification shapenzi = new ShapeSpecification("Ellipse", startingPosition);
            shapenzi.ShowDialog();            
        }

        private void DrawRectangle()
        {
            var cursorPosition = Mouse.GetPosition(MyCanvas);
            Point startingPosition = new Point(cursorPosition.X, cursorPosition.Y);
            ShapeSpecification shapenzi = new ShapeSpecification("Rectangle", startingPosition);
            shapenzi.ShowDialog();
        }

        private void DrawPolygon()
        {
            var cursorPosition = Mouse.GetPosition(MyCanvas);
            Point startingPosition = new Point(cursorPosition.X, cursorPosition.Y);
            ShapeSpecification shapenzi = new ShapeSpecification("Polygon", startingPosition, polygonPoints);
            shapenzi.ShowDialog();
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

                if (polygonPoints.Count > 0)
                {
                    Line line = new Line() { X1 = polygonPoints[polygonPoints.Count - 1].X, Y1 = polygonPoints[polygonPoints.Count - 1].Y,
                        X2 = pointPosition.X, Y2 = pointPosition.Y, Stroke = Brushes.Black };
                    MyCanvas.Children.Add(line);
                }
                
                MyCanvas.Children.Add(dot);
                Canvas.SetLeft(dot, pointPosition.X);
                Canvas.SetTop(dot, pointPosition.Y);

                polygonPoints.Add(pointPosition);
                
            }
        }
    }
}
