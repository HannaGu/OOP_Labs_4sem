using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace Lab6_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GridPrincipal.Children.Add(new MainControl());
            this.Cursor = Cursors.None;
            StreamResourceInfo sri = Application.GetResourceStream(
             new Uri("Cursor/1.cur", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;
        }
               
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            ListViewMenu.SelectedItem = null;
                     
            switch (index)
            {
                case 0:
                    for (int i=0; i<ProductControl.p.Count(); i++)
                    {
                        ProductControl.p.RemoveAt(i);
                    }
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new MainControl());
                    break;
                case 1:
                    AddItemWindow itemwin = new AddItemWindow();
                    itemwin.Show();
                    break;
                case 2:
                    DeleteWindow deletewin = new DeleteWindow();
                    deletewin.Show();
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new SettingsControl());
                    break;

                default: break;
            }
        }      

        private Command searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return searchCommand ??
                  (searchCommand = new Command(obj =>
                  {
                  try
                  {
                          ObservableCollection<Product> items = new ObservableCollection<Product>();
                          ObservableCollection<Product> result = new ObservableCollection<Product>();
                          items = Serializer.Serializer.Deserialiaze("D:\\СЕМ 4\\ООТП_2\\Lab6-7\\Lab6-7\\bin\\Debug\\Items.xml");
                          var buf = from p in items
                                    where p.Name.Equals(searchTB.Text)
                                    select p;
                          
                          foreach(Product i in buf )
                          {
                          result.Add(i);
                          }

                          GridPrincipal.Children.Clear();
                          GridPrincipal.Children.Add(new MainControl(result));

                      }
                      catch
                      {
                          MessageBox.Show("Введены некорретные данные!");
                      }
                  }));
            }
        }

        private void Sorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Sorting.SelectedIndex;
            ObservableCollection<Product> items = new ObservableCollection<Product>();
            ObservableCollection<Product> result = new ObservableCollection<Product>();
            items = Serializer.Serializer.Deserialiaze("D:\\СЕМ 4\\ООТП_2\\Lab6-7\\Lab6-7\\bin\\Debug\\Items.xml");
            switch (index)
            {
                case 0:
                    {
                        var buf = from p in items
                                  orderby p.Id
                                  select p;
                        foreach (Product i in buf)
                        {
                            result.Add(i);
                        }
                        items.Clear();
                        GridPrincipal.Children.Clear();
                        GridPrincipal.Children.Add(new MainControl(result));
                    }                
                    break;
                case 1:
                    {
                        var buf = from p in items
                                  orderby p.Name
                                  select p;
                        foreach (Product i in buf)
                        {
                            result.Add(i);
                        }
                        items.Clear();
                        GridPrincipal.Children.Clear();
                        GridPrincipal.Children.Add(new MainControl(result));
                    }
                    break;
                case 2:
                    {
                        var buf = from p in items
                                  orderby p.Price
                                  select p;
                        foreach (Product i in buf)
                        {
                            result.Add(i);
                        }
                        items.Clear();
                        GridPrincipal.Children.Clear();
                        GridPrincipal.Children.Add(new MainControl(result));
                    }
                    break;
            }
        }
    }
}
