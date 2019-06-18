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
        public Task task = new Task();
        public MainWindow()
        {
            InitializeComponent();
            db = TaskDbContext.GetInstance;
            ListaZadan_Loaded(null, null);
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
            listaKategorii.SelectedItem = 0;
        }

        //wyswietlenie wszystkich zadan
        private void ListaZadan_Loaded(object sender, RoutedEventArgs e)
        {
            List<Task> TaskList = db.Tasks.ToList();
            listaZadan.ItemsSource = TaskList;
        }

        //wyswietlenie zadan zaleznie od taskow
        private void ListaKategorii_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Task> FilteredTaskList =
                (from tasks in db.Tasks.ToList()
                 where tasks.category.Id == (listaKategorii.SelectedItem as Category).Id
                 select tasks).ToList();

            listaZadan.ItemsSource = FilteredTaskList;
        }

        private void listaZadan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SzczegolyZadaniaWindow okno = new SzczegolyZadaniaWindow();
            okno.task = listaZadan.SelectedItem as Task;
            if (okno.ShowDialog() == true)
            {
                //odswiezenie listy
                ListaZadan_Loaded(null, null);
            }
        }

        private void ShowDoneButton_Click(object sender, RoutedEventArgs e)
        {
            List<Task> FilteredTaskList =
                (from tasks in db.Tasks.ToList()
                 where tasks.IsDone == true
                 select tasks).ToList();
            listaZadan.ItemsSource = FilteredTaskList;
        }

        private void DeleteDoneButton_Click(object sender, RoutedEventArgs e)
        {
            List<Task> list = db.Tasks.ToList();
            foreach(Task task in list)
            {
                if(task.IsDone == true)
                {
                    db.Tasks.Remove(task);
                }
            }
            db.SaveChanges();
            ListaZadan_Loaded(null, null);
        }

        private void deleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć kategorie i powiązane z nia zadania?",
                "Uwaga", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                Category c = listaKategorii.SelectedItem as Category;
                List<Task> FilteredTaskList =
                    (from tasks in db.Tasks.ToList()
                    where tasks.category.Id == (listaKategorii.SelectedItem as Category).Id
                    select tasks).ToList();
                db.Categories.Remove(c);
                foreach (Task task in FilteredTaskList)
                {
                    db.Tasks.Remove(task);
                }
                db.SaveChanges();
                listaKategorii.SelectedIndex = 0;
                ListaKategorii_Loaded(null, null);
            }

        }

        private void SearchDB(object sender, TextChangedEventArgs args)
        {
            string text = SearchBar.Text;
            if (text == "Wszystkie zadania")
                return;
            List<Task> searchingResult =
                (from tasks in db.Tasks.ToList()
                 where tasks.Title == text
                 select tasks).ToList();
            listaZadan.ItemsSource = searchingResult;
        }
    }
}
