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
using System.Xml.Serialization;
using System.IO;
using System.Windows.Resources;
using System.Collections.ObjectModel;

namespace Lab6_7
{
    /// <summary>
    /// Логика взаимодействия для MainControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
        public static ObservableCollection<Product> products { get; set; }
       
        public MainControl()
        {
            InitializeComponent();

            this.Cursor = Cursors.None;
            StreamResourceInfo sri = Application.GetResourceStream(
             new Uri("Cursor/1.cur", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;

            products= Serializer.Serializer.Deserialiaze("D:\\СЕМ 4\\ООТП_2\\Lab6-7\\Lab6-7\\bin\\Debug\\Items.xml");
            productList.ItemsSource = products;
        }

        public MainControl(ObservableCollection<Product> list)
        {
            InitializeComponent();
            productList.ItemsSource = list;
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GridItems.Children.Clear();            
            GridItems.Children.Add(new ProductControl());           
            ProductControl.p.Add((Product)productList.SelectedItem);
        }
    }
}
