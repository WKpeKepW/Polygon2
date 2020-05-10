﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygon_2
{
    public partial class Form3 : Form
    {
        StreamReader Sr;
        StreamWriter Sw;
        string text;
        public Form3()
        {
            InitializeComponent();
            Sr = new StreamReader(Application.StartupPath + "\\config.txt");
            text = Sr.ReadToEnd();
            string[] buff = text.Split(';');
            try
            {
                textBox1.Text = buff[0];
                textBox2.Text = buff[1];
                textBox3.Text = buff[2];
                textBox4.Text = buff[3];
                textBox5.Text = buff[4];
                textBox6.Text = buff[5];
            }
            catch (Exception) {}
            Sr.Close();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Sw = new StreamWriter(Application.StartupPath + "\\config.txt",false);
            string text = null;
            string[] buff =
           {textBox1.Text+';',
            textBox2.Text+';',
            textBox3.Text+';',
            textBox4.Text+';',
            textBox5.Text+';',
            textBox6.Text};
            for (int i = 0; i <= 5; i++)
            {
                text = text + buff[i];
            }
            Sw.Write(text);
            Sw.Close();
            MessageBox.Show("Настройки успешно изменены");
        }
    }
}
