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

namespace NumberDuctParts
{
    /// <summary>
    /// Interaction logic for ConfirmDelete.xaml
    /// </summary>
    public partial class ConfirmDelete : Window
    {
        public ConfirmDelete()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            //If yes reset all values and close form
            tools.resetValues();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //If no just close the form
            this.Close();
        }
    }
}
