using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Projekt.Models;

namespace Projekt.Controllers
{
    sealed class TreeViewController
    {
        private TaskDbContext db = new TaskDbContext();
        private TreeView treeView;
        private static TreeViewController instance = null;

        //singleton lul
        public static TreeViewController GetInstance()
        {
            if (instance == null)
            {
                instance = new TreeViewController();
                return instance;
            }
            return instance;
        }

        private TreeViewController()
        {
            MainWindow mainWin = Application.Current.Windows.Cast<Window>()
                .FirstOrDefault(w => w is MainWindow) as MainWindow;

            treeView = mainWin.MainTreeView;
            treeView.DataContext = db.Database;
        }

        public void PopulateTree()
        {

        }

        public List<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
        }

    }
}
