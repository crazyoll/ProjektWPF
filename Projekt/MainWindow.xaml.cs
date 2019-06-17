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
        private TaskDbContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = TaskDbContext.GetInstance;
            ListaZadan_Loaded(null, null);
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
            addTaskWindow.category = listaKategorii.SelectedItem as Category;
            if (addTaskWindow.ShowDialog() == true)
            {
                //odswiezenie listy
                ListaKategorii_SelectionChanged(null, null);
            }
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryWindow addCategoryWindow = new AddCategoryWindow();
            if (addCategoryWindow.ShowDialog() == true)
            {
                //odswiezenie listy
                ListaKategorii_Loaded(null, null);
            }
        }

        //wyswietlenie wszystkich kategorii
        private void ListaKategorii_Loaded(object sender, RoutedEventArgs e)
        {
            List<Category> categoryList = db.Categories.ToList();
            listaKategorii.ItemsSource = categoryList;
            listaKategorii.DisplayMemberPath = "Name";
            listaKategorii.SelectedItem = 0;
        }

        //wyswietlenie wszystkich zadan
        private void ListaZadan_Loaded(object sender, RoutedEventArgs e)
        {
            List<Task> TaskList = db.Tasks.ToList();
            listaZadan.ItemsSource = TaskList;
            //listaZadan.DisplayMemberPath = "CustomString";
        }

        //wyswietlenie zadan zaleznie od taskow
        private void ListaKategorii_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Category> xd = db.Categories.ToList();
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
            //listaZadan.DisplayMemberPath = "CustomString";
        }

        private void listaZadan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SzczegolyZadaniaWindow okno = new SzczegolyZadaniaWindow();
            if (okno.ShowDialog() == true)
            {
                //odswiezenie listy
                ListaZadan_Loaded(null, null);
            }
        }

        private void ShowDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteDoneButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
