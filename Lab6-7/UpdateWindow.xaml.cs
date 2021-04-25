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
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Collections.ObjectModel;
using System.Windows.Resources;

namespace Lab6_7
{
    /// <summary>
    /// Логика взаимодействия для UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();
            currentProduct.ItemsSource = ProductControl.p;

            this.Cursor = Cursors.None;
            StreamResourceInfo sri = Application.GetResourceStream(
             new Uri("Cursor/1.cur", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;
        }

        private Command updCommand;
        private Command closeCommand;
        public ICommand UpdCommand
        {
            get
            {
                return updCommand ??
                  (updCommand = new Command(obj =>
                  {
                      try
                      {
                         string id =Convert.ToString(ProductControl.p[0].Id);
                         Serializer.Serializer.RewriteXML("D:\\СЕМ 4\\ООТП_2\\Lab6-7\\Lab6-7\\bin\\Debug\\Items.xml", id ,ProductControl.p);
                      }
                      catch
                      {
                         MessageBox.Show("Введены некорретные данные!");
                      }
                  }));
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return closeCommand ??
                  (closeCommand = new Command(obj =>
                  {
                      this.Close();
                  }));
            }
        }
    }
}
