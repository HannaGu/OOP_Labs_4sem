using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab2_3
{
    public partial class LecturerSearch : Form
    {
        public string request;
        public LecturerSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.discipArr=Form1.serializer.Deserialiaze("D://СЕМ 4//ООТП_2//Lab2-3//Lab2-3//Discipline.xml");
            try
            {
                string pattern = @"^[A-Za-zА-Яа-я\s]+$";
                Regex regex = new Regex(pattern);
                if (!regex.IsMatch(textBox1.Text))
                {
                    textBox1.Clear();
                    throw new Exception("Некорректный ввод данных");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

            request = textBox1.Text;
            var result = from d in Form1.discipArr where d.lecturer.name == request select d;
            if (result.Count() == 0)
            {
                
                string pattern = @"^[" + request[0] + @"](\w)*$";
                var resultReg = from d in Form1.discipArr where Regex.IsMatch(d.lecturer.name, pattern, RegexOptions.IgnoreCase) select d;
                if (resultReg.Count() == 0) textBox2.Text = "Совпадений не найдено";
                else
                {
                    foreach (Discipline i in resultReg)
                    {
                        textBox2.Text += "Предмет: " + i.discipline + ", лектор: " + i.lecturer.name +", курс: " + i.course + ", семестр: " + i.sem + "\r\n"; 
                    }
                    for (int i = 0; i < resultReg.Count(); i++)
                    { Form1.discipArr[i] = resultReg.ElementAt(i); }
                }
            }
            else 
            {
                foreach (Discipline i in result)
                {
                    textBox2.Text += "Предмет: " + i.discipline +", лектор: " + i.lecturer.name +", курс: " + i.course +", семестр: " + i.sem + "\r\n"; ;
                }
                for (int i = 0; i < result.Count(); i++)
                { Form1.discipArr[i] = result.ElementAt(i); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Discipline d in Form1.discipArr)
            { Form1.serializer.AddNode(d, "D://СЕМ 4//ООТП_2//Lab2-3//Lab2-3//Search.xml"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
