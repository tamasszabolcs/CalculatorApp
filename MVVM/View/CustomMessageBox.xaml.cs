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

namespace CalculatorApp.MVVM.View
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string message)
        {
            InitializeComponent();

            MessageTextBlock.Text = message;
            MessageTextBlock.Foreground = Brushes.Red;
            this.Background = Brushes.White;
            this.FontSize = 12;
            
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
