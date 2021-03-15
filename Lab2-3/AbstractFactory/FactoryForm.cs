using System;
using System.Windows.Forms;
using Lab2_3.Builder;
using Lab2_3.Singleton;
using Lab2_3.Prototype;

namespace Lab2_3.AbstractFactory
{
    public partial class FactoryForm : Form
    {
        public FactoryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            Discipline d1 = new Discipline(new Discipline1());
            richTextBox1.Text+=d1.Name();
            richTextBox1.Text +="\r\n"+d1.Person();

            Discipline d2 = new Discipline(new Discipline2());
            richTextBox1.Text += "\r\n"+d2.Name();
            richTextBox1.Text += "\r\n"+d2.Person();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            Director dir = new Director();
            SubjectBuilder builder = new Subject1();
            BSubject economy = dir.Build(builder);
            richTextBox1.Text += economy.ToString();
 
            builder = new Subject2();
            BSubject dataBases = dir.Build(builder);
            richTextBox1.Text += dataBases.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            App app = new App();
            app.Launch(14545, "Calibri");
            richTextBox1.Text += "Color: " + app.settings.Color + "\n" + "Font: " + app.settings.FontStyle + "\n";
                
            //cannot be changed
            app.settings = Settings.getInstance(142, "Times New Roman");
            richTextBox1.Text += "Color: " + app.settings.Color + "\n" + "Font: " + app.settings.FontStyle + "\n";
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            IAud room = new LectAuditorium(100);
            IAud clonedRoom = room.Clone();
            richTextBox1.Text += room.GetInfo();
            richTextBox1.Text += "Clone: "+clonedRoom.GetInfo();

            IAud room2 = new Lab(30, 15);
            IAud clonedRoom2 = room2.Clone();
            richTextBox1.Text += room2.GetInfo();
            richTextBox1.Text += "Clone: " + clonedRoom2.GetInfo();

        }
    }
}
