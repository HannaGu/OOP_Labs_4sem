using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_3
{
    public partial class CourceSearch : Form
    {
        uint crs;
        public CourceSearch()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            crs = Convert.ToUInt32(comboBox1.Text);
            Form1.discipArr = Form1.serializer.Deserialiaze("D://СЕМ 4//ООТП_2//Lab2-3//Lab2-3//Discipline.xml");
            textBox2.Text = "";
            var result = from d in Form1.discipArr where d.course == crs select d;
            if (result.Count() == 0)
            {
               textBox2.Text = "Совпадения не найдены";
            }
            else
            {
                foreach (Discipline i in result)
                {
                    textBox2.Text +="Предмет: "+ i.discipline +", лектор: " + i.lecturer.name +", курс: " + i.course +", семестр: " + i.sem + "\r\n";
                }
                for (int i = 0; i < result.Count(); i++)
                { Form1.discipArr[i] = result.ElementAt(i); }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Discipline d in Form1.discipArr)
            { Form1.serializer.AddNode(d, "D://СЕМ 4//ООТП_2//Lab2-3//Lab2-3//Search.xml"); }
        }
    }
}
