using Projekt.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            //jakies przykladowe dane aby sprawdzic dzialanie bazy
            //TaskDbContext db = new TaskDbContext();
            //Category category = new Category { Id = 1, Name = "Done" };
            //db.Categories.Add(category);
            //Task task = new Task
            //{
            //    Id = 1,
            //    category = category,
            //    EndDate = DateTime.Now,
            //    Description = "wazny opis",
            //    Priority = 1,
            //    Title = "bojowe zadanie",
            //    IsDone = false
            //};
            //db.Tasks.Add(task);
            //Step step = new Step { Id = 1, task = task, Description = "wazny krok", IsDone = false };
            //db.Steps.Add(step);
            //db.SaveChanges();
        }
    }
}
