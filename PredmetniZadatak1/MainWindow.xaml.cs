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
        //Brush customColor;
        //Random r = new Random();                

        private enum MyShape
        {
            Ellipse, Rectangle, Polygon
        };

        private MyShape currentShape = MyShape.Ellipse;
        Point clickPoint;

        public MainWindow()
        {
            InitializeComponent();
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
            ShapeSpecification shapenzi = new ShapeSpecification();
            shapenzi.ShowDialog();
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            currentShape = MyShape.Rectangle;
            ShapeSpecification shapenzi = new ShapeSpecification();
            shapenzi.ShowDialog();
        }

        private void PolygonButton_Click(object sender, RoutedEventArgs e)
        {
            currentShape = MyShape.Polygon;
            ShapeSpecification shapenzi = new ShapeSpecification();
            shapenzi.ShowDialog();
        }

        private void DrawEllipse()
        {
            Ellipse newEllipse = new Ellipse()
            {
                Stroke = Brushes.Black,
                Fill = Brushes.Purple,
                StrokeThickness = 4,
                Height = 10,
                Width = 10
            };

            // Defines the left part of the ellipse
            newEllipse.SetValue(Canvas.LeftProperty, clickPoint.X);
            newEllipse.Width = 100;

            // Defines the top part of the ellipse
            newEllipse.SetValue(Canvas.TopProperty, clickPoint.Y - 50);
            newEllipse.Height = 100;

            MyCanvas.Children.Add(newEllipse);
        }

        private void DrawRectangle()
        {

        }

        private void DrawPolygon()
        {

        }        
    }
}
