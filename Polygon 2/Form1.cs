using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygon_2
{
    public partial class Form1 : Form
    {
        Form2 f2;
        Form3 f3;
        static public string user;
        public Form1()
        {
            InitializeComponent();
            Form3.ChangeLanguage += ChangeLanguageForm;
        }
        void ChangeLanguageForm()
        {
            SetLanguage.Set(this);
            Text = SetLanguage.SetString(Text);
            if (SetLanguage.IsEnglishOn)
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\picture\\EnterEN.png");
            else
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\picture\\EnterRU.png");
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == false)
            {
                textBox2.UseSystemPasswordChar = true;
                pictureBox1.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\\picture\\Eye_open.png");
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
                pictureBox1.Image = System.Drawing.Image.FromFile(Application.StartupPath + "\\picture\\Eye_closed.png");
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            SqlCreater sql = new SqlCreater();
            DataTable dt = sql.Show(quary: "Select * From `authorization` where `login`= '" + textBox1.Text + "' and `pass` = '" + textBox2.Text + "' ;");
            if (dt.Rows.Count == 1)
            {
                user = textBox1.Text;
                f2 = new Form2();
                if (f3 != null)
                    f3.Dispose();
                f2.Show();
                this.Hide();
            }
            else
            {
                if (sql.Exeptionerror == 0)
                {
                    MessageBox.Show(SetLanguage.SetString("Ошибка авторизации"));
                }
            }
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            f3 = new Form3();
            f3.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = "admin";
            f2 = new Form2();
            if (f3 != null)
                f3.Dispose();
            f2.Show();
            this.Hide();
        }
    }
}
