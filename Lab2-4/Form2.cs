using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab2_3
{
    public partial class Form2 : Form
    {
        uint crs;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.discipArr = Form1.serializer.Deserialiaze("D://СЕМ 4//ООТП_2//Lab2-3//Lab2-3//Discipline.xml");
            richTextBox1.Text = "";

            Regex r = new Regex(textBox1.Text);
            Regex r2 = new Regex(textBoxSem.Text);
            List<Discipline> arr = new List<Discipline>();
            if (textBox1.Text != "" && textBoxSem.Text != "" && comboBox1.SelectedIndex != -1)
            {
                foreach (Discipline d in Form1.discipArr)
                {
                    if (r.IsMatch(d.lecturer.name) && r2.IsMatch(d.sem) && d.course == Convert.ToUInt32(comboBox1.Text))
                        arr.Add(d);
                }
                if (arr.Count == 0) richTextBox1.Text = "Точных совпадений не найдено";
            }
            else
            {
                foreach (Discipline d in Form1.discipArr)
                {
                    if (textBox1.Text != "" && r.IsMatch(d.lecturer.name))
                    { arr.Add(d); continue; }
                    if (textBoxSem.Text != "" && r2.IsMatch(d.sem))
                    { arr.Add(d); continue; }
                    if (d.course == Convert.ToUInt32(comboBox1.Text))
                    { arr.Add(d); continue; }
                }
            }

            foreach (Discipline i in arr)
            {
                richTextBox1.Text += "Предмет: " + i.discipline + ", лектор: " + i.lecturer.name + ", курс: " + i.course + ", семестр: " + i.sem + "\r\n";
            }
            for (int i = 0; i < arr.Count(); i++)
            { Form1.discipArr[i] =arr.ElementAt(i); }

            //try
            //{
            //    string request = "";
            //    string pat = @"^[A-Za-zА-Яа-я\s]+$";
            //    Regex regex = new Regex(pat);

            //    if (!regex.IsMatch(textBox1.Text))
            //    {
            //        textBox1.Clear();
            //        throw new Exception("Некорректный ввод данных");
            //    }
            //    else { request = textBox1.Text; }            

            //    string text = "";
            //    foreach (int index in checkedListBoxSem.CheckedIndices)
            //    {
            //        text += Convert.ToString(index + 1) + ";";
            //    }

            //    var result = from d in Form1.discipArr
            //                 where Regex.IsMatch(d.lecturer.name, request , RegexOptions.IgnoreCase) && d.course==crs
            //                 &&
            //                 d.sem.Equals(text) 
            //                  select d;
            //    if (result.Count() == 0)
            //    {
            //        string pattern = @"^[" + request[0] + @"](\w)*$";
            //        var resultReg = from d in Form1.discipArr where Regex.IsMatch(d.lecturer.name, pattern, RegexOptions.IgnoreCase) && d.course == crs && d.sem.Equals(text) select d;
            //        if (resultReg.Count() == 0) 
            //            richTextBox1.Text = "Совпадений не найдено";
            //        else
            //        {
            //            foreach (Discipline i in resultReg)
            //            {
            //                richTextBox1.Text += "Предмет: " + i.discipline +
            //                            ", лектор: " + i.lecturer.name +
            //                            ", курс: " + i.course +
            //                            ", семестр: " + i.sem + "\r\n";
            //            }
            //        }
            //    }
            //    else
            //    { foreach (Discipline i in result)
            //      {
            //         richTextBox1.Text += "Предмет: " + i.discipline +
            //                              ", лектор: " + i.lecturer.name +
            //                              ", курс: " + i.course +
            //                              ", семестр: " + i.sem + "\r\n";
            //      }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "ERROR");
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            textBoxSem.Clear();
            richTextBox1.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            foreach (Discipline d in Form1.discipArr)
            { Form1.serializer.AddNode(d, "D://СЕМ 4//ООТП_2//Lab2-3//Lab2-3//Search.xml"); }
        }
    }
}
