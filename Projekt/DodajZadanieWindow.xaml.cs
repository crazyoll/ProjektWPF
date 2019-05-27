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
        public DodajZadanieWindow()
        {
            InitializeComponent();
        }
        private void CategoryComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> categoryList = new List<string>();
            categoryList.Add("TestCategory1");
            categoryList.Add("TestCategory2");

            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = categoryList;
            comboBox.SelectedItem = 0;
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
        }
    }
}
