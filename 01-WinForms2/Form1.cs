using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_WinForms2
{
    public partial class Form1 : Form
    {
        List<Countries> CountriesInfo = new List<Countries>();
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("Data.dima"))
            {
                using (var fs = new FileStream("Data.dima", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    CountriesInfo =  bf.Deserialize(fs) as List<Countries>;
                }
            }
        }

        private void InitBox()
        {
            foreach (var item in CountriesInfo)
            {
                comboBox1.Items.Add(item.Country);
            }
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                foreach (var item in CountriesInfo)
                {
                    if (item.Country == comboBox1.Text)
                        item.Add(textBox1.Text);
                }
                textBox1.Text = String.Empty;
                Show();
                Serialize();
            }
        }
        private void Show()
        {
            listBox1.Items.Clear();
     
            foreach (var countries in CountriesInfo)
            {
                if (countries.Country == comboBox1.Text)
                    listBox1.Items.AddRange(countries.Cities.ToArray());           
            }

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var countries in CountriesInfo)
            {
                if (countries.Country == comboBox1.Text)
                    countries.Delete(listBox1.Text);
            }
            Show();
            Serialize();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                foreach (var item in CountriesInfo)
                {
                    if (item.Country == comboBox1.Text)
                        item.Rename(listBox1.Text, textBox2.Text);
                }
                textBox2.Text = String.Empty;
                Show();
                Serialize();
            }
        }
        private void Serialize()
        {
                using (var fs = new FileStream("Data.dima", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, CountriesInfo);
                }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox3.Text != "")
                 CountriesInfo.Add(new Countries(textBox3.Text));
            Show();
        }

        //private void textBox3_TextChanged(object sender, EventArgs e)
        //{
        //    if (textBox3.Text != "" && Char.IsDigit(textBox3.Text.Last()))
        //        textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length-1);
        //    //textBox3.
        //}
    }
}
