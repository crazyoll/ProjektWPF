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
        private TaskDbContext db = new TaskDbContext();
        public AddCategoryWindow()
        {
            InitializeComponent();
        }

        private void AddCategoryToDB(object sender, RoutedEventArgs e)
        {
            Category category = new Category { Name = CategoryNameBar.Text };
            db.Categories.Add(category);
            db.SaveChanges();
            this.Close();
        }
    }
}
