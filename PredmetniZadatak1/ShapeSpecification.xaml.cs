using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace PredmetniZadatak1
{
    /// <summary>
    /// Interaction logic for ShapeSpecification.xaml
    /// </summary>
    public partial class ShapeSpecification : Window
    {                
        public ShapeSpecification()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;       
        private string objwidth;
        

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

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void drawBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void objWidth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
