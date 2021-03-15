using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01_textCalc
{
    public partial class Form1 : Form
    {
        public string n1;
        public string operation;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            n1 = textBox1.Text;
            Button B = (Button)sender;
            operation = B.Text;
            textBox1.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void get_by_indx_Click(object sender, EventArgs e)
        {
            n1 = textBox1.Text;   
            Button B = (Button)sender;
            operation = B.Text;
            textBox1.Text = "";
        }
        private void length_Click(object sender, EventArgs e)
        {
            n1 = textBox1.Text;
            textBox1.Text = Convert.ToString(n1.Length);
        }
        private void vowel_Click(object sender, EventArgs e)
        {
            int count = 0;
            string vow = "AaEeIiOoUuYyАаУуОоЫыИиЭэЯяЮюЁёЕе";
            n1 = textBox1.Text;
            foreach(char c in n1)
            {
                if (vow.IndexOf(c) != -1)
                    count++;
            }
            textBox1.Text=Convert.ToString(count);   
        }
        private void consonant_Click(object sender, EventArgs e)
        {
            int count = 0;
            string vow = "AaEeIiOoUuYyАаУуОоЫыИиЭэЯяЮюЁёЕе";
            string punct = " /()+-=* !?.,-;:0123456789";
            n1 = textBox1.Text;
            foreach (char c in n1)
            {
                if (vow.IndexOf(c) == -1&&punct.IndexOf(c)==-1)
                    count++;
            }
            textBox1.Text = Convert.ToString(count);
        }

        private void sentences_Click(object sender, EventArgs e)
        {
            string punct = ".!?";
            int count = 0;
            n1 = textBox1.Text;
            foreach (char c in n1)
            {
                if (punct.IndexOf(c) != -1)
                    count++;
            }
            textBox1.Text = Convert.ToString(count);
        }
        private void replace_Click(object sender, EventArgs e)
        {
            n1 = textBox1.Text;
            Button B = (Button)sender;
            operation = B.Text;
            textBox1.Text = "";
        }

        private void words_Click(object sender, EventArgs e)
        {
            int count = 1;
            string punct = " ,.!?";
            n1 = textBox1.Text;
            for (int i=0;i<n1.Length;i++)
            {
                
                if (n1[i]==' '&&punct.IndexOf(n1[i+1])==-1)
                    count++;

            }
            textBox1.Text = Convert.ToString(count);
        }
        private void equal_Click(object sender, EventArgs e)
        {
            string result="", n2;
            char symb;
            int indxN2;

            switch(operation)
            {
                case "delete": {
                        n2 = textBox1.Text;
                        indxN2=n1.IndexOf(n2);

                        if(indxN2 ==-1)
                            throw new Exception("Подстрока не найдена");
                       
                        result = n1.Remove(indxN2, n2.Length);
                        break;
                    }
                case "get_by_indx": {
                        string str= "0123456789";
                        foreach(char c in textBox1.Text)
                        { 
                            if (str.IndexOf(c) == -1)
                                throw new Exception("Индекс должен быть числом");
                        }
                        indxN2 = Convert.ToInt32(textBox1.Text);
                        if (indxN2 > n1.Length)
                            throw new Exception("Индекс превышает длину строки");
                        symb = n1[indxN2];
                        result = Convert.ToString(symb);
                        break;
                    }
                case "replace": {
                        bool sharp = false;
                        n2 = textBox1.Text;
                        string first="", second="";
                        foreach(char c in n2)
                        {
                            if (c == '#') { sharp = true; continue; }
                            if(!sharp) first+=c;
                            else second += c;
                        }
                        if (n1.IndexOf(first) == -1)
                            throw new Exception("Подстрока для замены не найдена");
                        result=n1.Replace(first, second);
                        break;
                    }
                
            }
            textBox1.Text = result;
            operation = "";
            n1 = "";
        }

       
    }
}
