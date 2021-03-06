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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace extraction_front
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page1();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page2();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (toolselection.SelectedValue == null)
            {
                return;
            }
            switch(toolselection.SelectedValue.ToString()) {
                case "exfp3":
                    Main.Content = new Page1();
                    break;
                case "versatile single switch":
                    Main.Content = new Page2();
                    break;
                default:
                    Main.Content = new Page2();
                    break;
            }
        }

    }
}
