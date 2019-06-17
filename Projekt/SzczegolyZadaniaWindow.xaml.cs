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

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy SzczegolyZadaniaWindow.xaml
    /// </summary>
    public partial class SzczegolyZadaniaWindow : Window
    {
        public SzczegolyZadaniaWindow()
        {
            InitializeComponent();
        }
        private void TaskNameBarGotFocus(object sender, RoutedEventArgs e)
        {
            if (TaskNameBar.Text == "Nowe zadanie...")
                TaskNameBar.Text = "";
        }

        private void TaskNameBarLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskNameBar.Text))
                TaskNameBar.Text = "Nowe zadanie...";
        }

        private void DescriptionBarGotFocus(object sender, RoutedEventArgs e)
        {
            if (DescriptionBar.Text == "Dodatkowy opis...")
                DescriptionBar.Text = "";
        }

        private void DescriptionBarLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DescriptionBar.Text))
                DescriptionBar.Text = "Dodatkowy opis...";
        }

        private void ButtonWindowMinimalize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonWindmowMaximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void ButtonWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
