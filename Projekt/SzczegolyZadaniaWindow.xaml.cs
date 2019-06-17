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
    /// Logika interakcji dla klasy SzczegolyZadaniaWindow.xaml
    /// </summary>
    public partial class SzczegolyZadaniaWindow : Window
    {
        private TaskDbContext db;
        public Task task = null;
        public SzczegolyZadaniaWindow()
        {
            db = TaskDbContext.GetInstance;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TaskNameBar.Text = task.Title;
            DescriptionBar.Text = task.Description;
            PriorityBar.Value = task.Priority;
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
            task.IsDone = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Task newTask = new Task
            {
                Title = TaskNameBar.Text,
                Description = DescriptionBar.Text,
                EndDate = DateBar.SelectedDate.Value,
                Priority = (int)PriorityBar.Value
            };
            db.Tasks.Remove(task);
            db.Tasks.Add(newTask);
            db.SaveChanges();
            DialogResult = true;
            this.Close();
        }
    }
}
