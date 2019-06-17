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

            //this.DataContext = new WindowViewModel(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            DodajZadanieWindow addTaskWindow = new DodajZadanieWindow();
            addTaskWindow.ShowDialog();
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryWindow addCategoryWindow = new AddCategoryWindow();
            addCategoryWindow.ShowDialog();
        }

        private void ListaKategorii_Loaded(object sender, RoutedEventArgs e)
        {
            TaskDbContext db = new TaskDbContext();
            List<Category> categoryList = db.Categories.ToList();
            listaKategorii.ItemsSource = categoryList;
            listaKategorii.DisplayMemberPath = "Name";
            listaKategorii.SelectedItem = 0;
        }

        private void ListaKategorii_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TaskDbContext db = new TaskDbContext();
            List<Task> FilteredTaskList =
                (from tasks in db.Tasks.ToList()
                 where tasks.category.Id == (listaKategorii.SelectedItem as Category).Id
                 select tasks).ToList();
            //if (FilteredTaskList.Count == 0)
            //{
            //    listaZadan.ItemsSource = FilteredTaskList;
            //    listaZadan.Items.Add("Brak zadań!");
            //}
            //else
            //{
            //    listaZadan.ItemsSource = FilteredTaskList;
            //    listaZadan.DisplayMemberPath = "Title";
            //}
            listaZadan.ItemsSource = FilteredTaskList;
            listaZadan.DisplayMemberPath = "Title";
        }
    }
}
