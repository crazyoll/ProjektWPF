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
    /// Interaction logic for AddCategoryWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {
        private TaskDbContext db;
        public AddCategoryWindow()
        {
            InitializeComponent();
            db = TaskDbContext.GetInstance;
        }

        private void AddCategoryToDB(object sender, RoutedEventArgs e)
        {
            Category category = new Category { Name = CategoryNameBar.Text };
            db.Categories.Add(category);
            db.SaveChanges();
            DialogResult = true;
            this.Close();
        }

        private void CategoryNameBarGotFocus(object sender, RoutedEventArgs e)
        {
            if (CategoryNameBar.Text == "Nazwa kategorii...")
                CategoryNameBar.Text = "";
        }

        private void CategoryNameBarLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CategoryNameBar.Text))
                CategoryNameBar.Text = "Nazwa kategorii...";
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
