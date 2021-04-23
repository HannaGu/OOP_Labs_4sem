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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace Lab6_7
{
    /// <summary>
    /// Логика взаимодействия для AddItemWindow.xaml
    /// </summary>
    public partial class AddItemWindow : Window
    {
        public AddItemWindow()
        {
            InitializeComponent();
            this.Cursor = Cursors.None;
            StreamResourceInfo sri = Application.GetResourceStream(
             new Uri("Cursor/1.cur", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;
        }
        private Command addCommand;
        private Command closeCommand;
        public ICommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new Command(obj =>
                  {
                  try
                  {
                      Product pr = new Product();
                          pr.Id = Convert.ToInt32(idTB.Text);
                          pr.Name = nameTB.Text;
                          pr.Description = descriptionTB.Text;
                          pr.Quantity = Convert.ToInt32(quantityTB.Text);
                          pr.Price = Convert.ToDouble(priceTB.Text);
                          pr.ImagePath = imgPathTB.Text;
                          pr.Color = colorTB.Text;
                          Serializer.Serializer.AddNode(pr, "D:\\СЕМ 4\\ООТП_2\\Lab6-7\\Lab6-7\\bin\\Debug\\Items.xml");
                          MainControl.products.Add(pr);
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
