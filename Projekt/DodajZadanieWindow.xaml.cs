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
    /// Interaction logic for DodajZadanieWindow.xaml
    /// </summary>
    public partial class DodajZadanieWindow : Window
    {
        private TaskDbContext db;
        public DodajZadanieWindow()
        {
            InitializeComponent();
            db = new TaskDbContext();
        }
        private void CategoryComboBox_Loaded(object sender, RoutedEventArgs e)
        {

            List<Category> categoryList = db.Categories.ToList();

            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = categoryList;
            comboBox.SelectedItem = 0;
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddTaskToDB(object sender, RoutedEventArgs e)
        {
            Task task = new Task
            {
                Title = TaskNameBar.Text,
                Description = DescriptionBar.Text,
                EndDate = DateBar.SelectedDate.Value,
                Priority = (int) PriorityBar.Value,
                category = (Category) CategoryBar.SelectedItem
            };
            db.Tasks.Add(task);
            db.SaveChanges();
            this.Close();
        }
    }
}
