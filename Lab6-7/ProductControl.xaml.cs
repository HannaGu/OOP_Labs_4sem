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
using System.Collections.ObjectModel;
using System.Windows.Resources;

namespace Lab6_7
{
    /// <summary>
    /// Логика взаимодействия для ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {

        public static ObservableCollection<Product> p = new ObservableCollection<Product>();
       
        public ProductControl()
        {
            InitializeComponent();
            products.ItemsSource = p;

            this.Cursor = Cursors.None;
            StreamResourceInfo sri = Application.GetResourceStream(
             new Uri("Cursor/1.cur", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {           
            UpdateWindow updwin = new UpdateWindow();
            updwin.Show();         
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
           int id = ProductControl.p[0].Id;
           Serializer.Serializer.DeleteNode("D:\\СЕМ 4\\ООТП_2\\Lab6-7\\Lab6-7\\bin\\Debug\\Items.xml", id);
           
        }
    }
}
