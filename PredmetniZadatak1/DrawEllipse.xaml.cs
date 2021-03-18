﻿using System;
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
using System.Windows.Shapes;

namespace PredmetniZadatak1
{
    /// <summary>
    /// Interaction logic for DrawEllipse.xaml
    /// </summary>
    public partial class DrawEllipse : Window
    {
        Ellipse ellipse = new Ellipse();
        public DrawEllipse()
        {
            InitializeComponent();
        }

        public DrawEllipse(Ellipse elipsa)
        {
            InitializeComponent();
            ellipse = elipsa;
        }
    }
}
