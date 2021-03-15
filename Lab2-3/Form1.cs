using System;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Lab2_3.AbstractFactory;


namespace Lab2_3
{
    public partial class Form1 : Form
    {
        int count = 0;
        uint crs;        
        public static List<Discipline> discipArr = new List<Discipline>();
        public static Serializer serializer = new Serializer();
        Discipline discip = new Discipline();
        Lecturer lector = new Lecturer();

        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            statusStrip1.Items[2].Text = $"Текущая дата: {DateTime.Now.ToString("yyyy.MM.dd  hh:mm:ss ")}";
        }

        private void trackBarLect_Scroll(object sender, EventArgs e)
        {
            currentValueLect.Text = String.Format("Текущее значение: {0}", trackBarLect.Value);
        }

        private void trackBarLabs_Scroll(object sender, EventArgs e)
        {
            currentValueLabs.Text = String.Format("Текущее значение: {0}", trackBarLabs.Value);
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            crs = Convert.ToUInt32(radioButton1.Text);
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            crs = Convert.ToUInt32(radioButton2.Text);
        }
        private void radioButton3_Click(object sender, EventArgs e)
        {
            crs = Convert.ToUInt32(radioButton3.Text);
        }
        private void radioButton4_Click(object sender, EventArgs e)
        {
            crs = Convert.ToUInt32(radioButton4.Text);
        }         
        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
               
                string FIO = @"^[A-Za-zА-Яа-я\s]+$";
                Regex regexFIO = new Regex(FIO);
                string DName = @"^[A-Za-zА-Яа-я\s]+$";
                Regex regexDName = new Regex(DName);
                string room = @"^[1-5]{1}[0-9]{2}-[1-4]{1}$";
                Regex regexRoom = new Regex(room);


                if (!regexFIO.IsMatch(textBoxFIO.Text))
                {
                    textBoxFIO.Clear();
                    throw new Exception("Некорректный ввод имени");
                }
                if (!regexDName.IsMatch(textBoxDiscipName.Text))
                {
                    textBoxDiscipName.Clear();
                    throw new Exception("Некорректное название дисциплины");
                }
                if (!regexRoom.IsMatch(textBoxRoom.Text))
                {
                    textBoxRoom.Clear();
                    throw new Exception("Некорректный ввод аудитории");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

           
            string text = ""; 

            discip.discipline = textBoxDiscipName.Text;
            discip.testing = comboBoxTesting.Text;
            discip.lections = Convert.ToUInt32(trackBarLect.Value);
            discip.labs = Convert.ToUInt32(trackBarLabs.Value);
            discip.course = crs;
            lector.name = textBoxFIO.Text;
            lector.room = textBoxRoom.Text;
            lector.department = comboBoxDepartment.Text;          

            discip.sem = textBoxSem.Text;
            text = "";
            foreach (string index in checkedListBoxSpec.CheckedItems)
            {
                text += index + ";";
            }
            discip.speciality = text;

            discip.lecturer = lector;
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
            }

          var results = new List<ValidationResult>();
          var context = new ValidationContext(discip);
          if (!Validator.TryValidateObject(discip, context, results, true))
          { 
              foreach (var error in results)
              {                      
              MessageBox.Show(error.ErrorMessage,"ERROR" );
              }
          }
          else{ serializer.AddNode(discip, "D://СЕМ 4//ООТП_2//Lab2-3//Lab2-3//Discipline.xml");
                count++;
                toolStripStatusLabel2.Text = $"Количество объектов: {count}";
            }
            toolStripStatusLabel1.Text = "Последнее действие: сохранить";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            toolStripStatusLabel1.Text = "Последнее действие: поиск";
        }

        private void поЛекторуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LecturerSearch Lector_searchForm = new LecturerSearch();
            Lector_searchForm.Show();
            toolStripStatusLabel1.Text = "Последнее действие: поиск";
        }

        private void поКурсуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourceSearch Cource_searchForm = new CourceSearch();
            Cource_searchForm.Show();
            toolStripStatusLabel1.Text = "Последнее действие: поиск";
        }

        private void поСеместуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SemSearch Sem_searchForm = new SemSearch();
            Sem_searchForm.Show();
            toolStripStatusLabel1.Text = "Последнее действие: поиск";
        }

        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Sorting sortForm = new Sorting();
           sortForm.Show();
            toolStripStatusLabel1.Text = "Последнее действие: сортировка";
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: 1.0 \r\n Hanna Gubar", "Information");
            toolStripStatusLabel1.Text = "Последнее действие: о программе";
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            textBoxDiscipName.Clear();
            textBoxFIO.Clear();
            textBoxRoom.Clear();
            textBoxSem.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            textBoxSem.Clear();
            for (int i = 0; i < checkedListBoxSpec.Items.Count; i++)
            {
                checkedListBoxSpec.SetItemChecked(i, false);
            }
            comboBoxTesting.SelectedIndex = -1;
            comboBoxDepartment.SelectedIndex = -1;
            trackBarLabs.Value = 0;
            trackBarLect.Value = 0;
            toolStripStatusLabel1.Text = "Последнее действие: очистить";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D://СЕМ 4//ООТП_2//Lab2-3//Lab2-3//Discipline.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            xRoot.RemoveAll();
            xDoc.Save("D://СЕМ 4//ООТП_2//Lab2-3//Lab2-3//Discipline.xml");
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
            }
            toolStripStatusLabel1.Text = "Последнее действие: удалить";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
             сортировкаToolStripMenuItem_Click(sender, e);
            toolStripStatusLabel1.Text = "Последнее действие: сортировка";
        }

        private void поЛекторуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            поЛекторуToolStripMenuItem_Click(sender, e);
            toolStripStatusLabel1.Text = "Последнее действие: поиск";
        }

        private void поКурсуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            поКурсуToolStripMenuItem_Click(sender, e);
            toolStripStatusLabel1.Text = "Последнее действие: поиск";
        }

        private void поСеместруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            поСеместуToolStripMenuItem_Click(sender, e);
            toolStripStatusLabel1.Text = "Последнее действие: поиск";
        }

        private void лаб4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FactoryForm ff= new FactoryForm();
            ff.Show();
        }

        private void скрытьПанельИнструментовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStrip1.Visible==false)
            {
                toolStrip1.Visible = true;
                скрытьПанельИнструментовToolStripMenuItem.Text = "+";
            }
            else
            {
                toolStrip1.Visible = false;
                скрытьПанельИнструментовToolStripMenuItem.Text = "-";
            }
        }
    }
}
