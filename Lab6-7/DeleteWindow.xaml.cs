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
using System.Text.RegularExpressions;
using System.Windows.Resources;

namespace Lab6_7
{
    /// <summary>
    /// Логика взаимодействия для DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
        {
            InitializeComponent();
            this.Cursor = Cursors.None;
            StreamResourceInfo sri = Application.GetResourceStream(
             new Uri("Cursor/1.cur", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;
        }
        private Command deleteCommand;
   
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new Command(obj =>
                  {
                  try
                  {
                      char[] separators = { ' ', ','};
                      string[] idStr = idTextBox.Text.Split(separators);
                      string[] resultarr=idStr.Where(x => Regex.IsMatch(x, @"^\d+$")).ToArray();
                      foreach (string s in resultarr)
                      {
                        int id = Convert.ToInt32(s);
                        Serializer.Serializer.DeleteNode("D:\\СЕМ 4\\ООТП_2\\Lab6-7\\Lab6-7\\bin\\Debug\\Items.xml", id);
                      }
                  }
                      catch
                      {
                          MessageBox.Show("Введены некорретные данные!");
                      }
                  }));  
            }
        }

    }
}
