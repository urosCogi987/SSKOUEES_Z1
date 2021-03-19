﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PredmetniZadatak1
{
    /// <summary>
    /// Interaction logic for ShapeSpecification.xaml
    /// </summary>
    public partial class ShapeSpecification : INotifyPropertyChanged
    {
        #region fields
        public event PropertyChangedEventHandler PropertyChanged;  
        
        private string objwidth;
        private string objheight;
        private Color fillcolor;
        private Color bordercolor;
        private string objborderthickness;
        private string typeComponent = String.Empty;

        // Starting coordinates
        private double startingX;
        private double startingY;
        private List<Point> polygonPoints;




        public string ObjWidth
        {
            get { return objwidth; }
            set
            {
                if (objwidth != value)
                {
                    objwidth = value;
                    OnPropertyChanged("ObjWidth");
                }
            }
        }

        public string ObjHeight
        {
            get { return objheight; }
            set
            {
                if (objheight != value)
                {
                    objheight = value;
                    OnPropertyChanged("ObjHeight");
                }
            }
        }

        public Color FillColor
        {
            get { return fillcolor; }
            set
            {
                if (fillcolor != value )
                {
                    fillcolor = value;
                    OnPropertyChanged("FillColor");
                }
            }
        }

        public Color BorderColor
        {
            get { return bordercolor; }
            set
            {
                if (bordercolor != value)
                {
                    bordercolor = value;
                    OnPropertyChanged("BorderColor");
                }
            }
        }

        public string ObjBorderThickness
        {
            get { return objborderthickness; }
            set
            {
                if (objborderthickness != value)
                {
                    objborderthickness = value;
                    OnPropertyChanged("ObjBorderThickness");
                }
            }
        }

        public double StartingX
        {
            get { return startingX; }
            set { startingX = value; }
        }

        public double StartingY
        {
            get { return startingY; }
            set { startingY = value; }
        }

        public List<Point> PolygonPoints
        {
            get { return polygonPoints; }
            set { polygonPoints = value; }
        }


        #endregion

        #region Constructors
        public ShapeSpecification()
        {
            InitializeComponent();
        }
        

        public ShapeSpecification(string componentType, Point startingPosition, List<Point> polygonPoints = null)
        {
            InitializeComponent();
            typeComponent = componentType;
            StartingX = startingPosition.X;
            StartingY = startingPosition.Y;
            PolygonPoints = polygonPoints;

            fillColorCmbBox.ItemsSource = typeof(Colors).GetProperties();
            fillColorCmbBox.SelectedIndex = 10;
            borderColorCmbBox.ItemsSource = typeof(Colors).GetProperties();
            borderColorCmbBox.SelectedIndex = 11;
        }
        #endregion

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void drawBtn_Click(object sender, RoutedEventArgs e)
        {
            double resultHeight;

            MainWindow main = ((MainWindow)Application.Current.MainWindow);
            SolidColorBrush fillColorCmbBox = new SolidColorBrush(FillColor);
            SolidColorBrush borderColorCmbBox = new SolidColorBrush(BorderColor);

            //if (!Double.TryParse(objWidth.Text, out resultHeight) || resultHeight < 1)
            if (typeComponent == "Ellipse")
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Name = "rectangle_PROBA";
                ellipse.Fill = fillColorCmbBox;
                ellipse.Stroke = borderColorCmbBox;
                ellipse.Width = Double.Parse(objWidth.Text);
                ellipse.Height = Double.Parse(objHeight.Text);
                ellipse.StrokeThickness = Double.Parse(objBorderThickness.Text);
                main.MyCanvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, StartingX);
                Canvas.SetTop(ellipse, StartingY);
                this.Close();
            }
            if (typeComponent == "Rectangle")
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Name = "rectangle_PROBA";
                rectangle.Fill = fillColorCmbBox;
                rectangle.Stroke = borderColorCmbBox;
                rectangle.Width = Double.Parse(objWidth.Text);
                rectangle.Height = Double.Parse(objHeight.Text);
                rectangle.StrokeThickness = Double.Parse(objBorderThickness.Text);
                main.MyCanvas.Children.Add(rectangle);
                Canvas.SetLeft(rectangle, startingX);
                Canvas.SetTop(rectangle, startingY);
                this.Close();
            }
            if (typeComponent == "Polygon")
            {

                Polygon polygon = new Polygon();
                foreach (Point pPoint in polygonPoints)
                {
                    polygon.Points.Add(pPoint);                    
                }
               
                polygon.Name = "polygon_PROBA";
                polygon.Fill = fillColorCmbBox;
                polygon.Stroke = borderColorCmbBox;
                polygon.StrokeThickness = Double.Parse(objBorderThickness.Text);
                main.MyCanvas.Children.Add(polygon);

                main.MyCanvas.Children.RemoveRange(main.MyCanvas.Children.Count - 2 * main.polygonPoints.Count, 2 * main.polygonPoints.Count - 1);
                main.polygonPoints.Clear();

                this.Close();
            }
        }

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }        

        private void fillColorCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillColor = (Color)(fillColorCmbBox.SelectedItem as PropertyInfo).GetValue(null, null);
        }        

        private void borderColorCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BorderColor = (Color)(borderColorCmbBox.SelectedItem as PropertyInfo).GetValue(null, null);
        }
    }
}
