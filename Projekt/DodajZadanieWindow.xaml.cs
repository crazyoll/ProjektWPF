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
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for DodajZadanieWindow.xaml
    /// </summary>
    public partial class DodajZadanieWindow : Window
    {
        private TaskDbContext db;
        public Category category = null;
        public DodajZadanieWindow()
        {
            db = TaskDbContext.GetInstance;
            InitializeComponent();
            
        }
        private void CategoryComboBox_Loaded(object sender, RoutedEventArgs e)
        {

            List<Category> categoryList = db.Categories.ToList();
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = categoryList;
            comboBox.DisplayMemberPath = "Name";
            comboBox.SelectedItem = 0;
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddTaskToDB(object sender, RoutedEventArgs e)
        {
            if ((TaskNameBar.Text == "Nowe zadanie...") || (DescriptionBar.Text == "Dodatkowy opis...") )
            {
                MessageBox.Show("Pola nie mogą być puste" , "Błąd danych", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Task task = new Task
                {
                    Title = TaskNameBar.Text,
                    Description = DescriptionBar.Text,
                    EndDate = DateBar.SelectedDate.Value,
                    Priority = (int)PriorityBar.Value,
                    category = category
                };
                db.Tasks.Add(task);
                db.SaveChanges();
                DialogResult = true;
                this.Close();
            }

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
    }
}
