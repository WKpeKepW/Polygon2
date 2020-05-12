using System;
using MySql.Data.MySqlClient;
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
    public partial class Form2 : Form
    {
        //сделать больше функций для обычного пользователя
        //сделать кнопки понятными по назначению
        SqlCreater sql;
        bool selectedtable = true;
        int statis;
        string users;
        void update()
        {
            if (Form1.user != "admin")
            {
                dataGridView1.DataSource = sql.Show(quary: "Select `Компания`,`Телефон / Email`,`Дата поступления` From `orders` where `Статус` = 'Не выполнен'; ");
                dataGridView2.DataSource = sql.Show(quary: "Select `Компания`,`Телефон / Email`,`Дата поступления` From `orders` where `Статус` = 'На выполнение' and `Исполнитель` = '" + Form1.user + "';");
                dataGridView3.DataSource = sql.Show(quary: "Select `Компания`,`Телефон / Email`,`Дата поступления` From `orders` where `Статус` = 'Выполнен' and `Исполнитель` = '" + Form1.user + "'; ");
            }
            else
            {
                dataGridView1.DataSource = sql.Show(quary: "Select `Компания`,`Телефон / Email`,`Дата поступления`,`Статус`,`Исполнитель` From `orders`");
                dataGridView2.DataSource = sql.Show(quary: "Select `Компания`,`Телефон / Email`,`Дата поступления`,`Статус`,`Исполнитель` From `orders` where `Статус` = 'На выполнение' ");
                dataGridView3.DataSource = sql.Show(quary: "Select `Компания`,`Телефон / Email`,`Дата поступления`,`Статус`,`Исполнитель` From `orders` where `Статус` = 'Выполнен'; ");
                dataGridView4.DataSource = sql.Show(quary: "Select * From `orders`");
                dataGridView5.DataSource = sql.Show("authorization");
                dataGridView6.DataSource = sql.Show("stat");
            }
        }

        public Form2()
        {
            InitializeComponent();
            Construct();
            ChangeLanguageForm();
            Form3.ChangeLanguage += ChangeLanguageForm;
        }
        void Construct()
        {
            if (Form1.user != "admin")
            { tabPage4.Parent = null; tabPage5.Parent = null; pictureBox15.Hide(); pictureBox16.Hide(); pictureBox17.Hide(); }
            sql = new SqlCreater();
            #region combo
            comboBox1.DataSource = comboBox2.Items;
            comboBox3.DataSource = comboBox2.Items;
            comboBox4.DataSource = comboBox2.Items;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox100.Items.AddRange(new string[] { "id_stat", "Пользователь", "Кол-во работ", "Последняя выполненая" });
            comboBox100.SelectedIndex = 0;
            textBox18.Hide();
            button100.Hide();
            button99.Hide();
            textBox98.Hide();
            button98.Hide();
            button97.Hide();
            #endregion
            update();
        }
        void ChangeLanguageForm()
        {
            Text = SetLanguage.SetString(Text);
            tabPage1.Text = SetLanguage.SetString(tabPage1.Text);
            tabPage2.Text = SetLanguage.SetString(tabPage2.Text);
            tabPage3.Text = SetLanguage.SetString(tabPage3.Text);
            if (Form1.user == "admin")
            {
                tabPage4.Text = SetLanguage.SetString(tabPage4.Text);
                tabPage5.Text = SetLanguage.SetString(tabPage5.Text);
            }
            SetLanguage.Set(this);
        }
        #region евенты доп инфы
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = sql.OneLine("orders", "Описание", dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());
                textBox2.Text = sql.OneLine("orders", "Доп.информация", dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());
                textBox10.Text = sql.OneLine("orders", "ФИО", dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            }
            catch (NullReferenceException)
            { MessageBox.Show(SetLanguage.SetString("Выберете запись")); }
        }
        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox4.Text = sql.OneLine("orders", "Описание", dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString());
                textBox3.Text = sql.OneLine("orders", "Доп.информация", dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString());
                textBox23.Text = sql.OneLine("orders", "ФИО", dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString());
            }
            catch (NullReferenceException)
            { MessageBox.Show(SetLanguage.SetString("Выберете запись")); }
        }
        private void DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox6.Text = sql.OneLine("orders", "Описание", dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.ToString());
                textBox5.Text = sql.OneLine("orders", "Доп.информация", dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.ToString());
                textBox24.Text = sql.OneLine("orders", "Доп.информация", dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.ToString());
            }
            catch (NullReferenceException)
            { MessageBox.Show(SetLanguage.SetString("Выберете запись")); }
        }
        #endregion
        #region кнопки 
        private void PictureBox9_Click(object sender, EventArgs e) //button1
        {
            try
            {
                sql.CommandToTable("Update `orders` Set `Статус` = 'На выполнение' where `Компания` = '" + dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString() + "';");
                sql.CommandToTable("Update `orders` Set `Исполнитель` = '" + Form1.user + "' where `Компания` = '" + dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString() + "';");
                update();
            }
            catch (NullReferenceException)
            { MessageBox.Show(SetLanguage.SetString("Выберете запись")); }
        }
        private void PictureBox11_Click(object sender, EventArgs e) //button2 
        {

            try {
                statis = Convert.ToInt32(sql.OneLine(quary: "Select `Кол-во работ` from stat Where `Пользователь` = '" + Form1.user + "';"));
                sql.CommandToTable("Update `orders` Set `Статус` = 'Выполнен' where `Компания` = '" + dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString() + "';");
                sql.CommandToTable("Update `orders` Set `Исполнитель` = '" + Form1.user + "' where `Компания` = '" + dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString() + "';");
                sql.CommandToTable("Update `stat` Set `Кол-во работ` = '" + (statis = statis + 1) + "' where `Пользователь` = '" + Form1.user + "'");
                sql.CommandToTable("Update `stat` Set `Последняя выполненая` = '" + DateTime.Now.ToShortDateString() + "' where `Пользователь` = '" + Form1.user + "'");
                update();
            }
            catch (NullReferenceException)
            { MessageBox.Show(SetLanguage.SetString("Выберете запись")); }
        }
        private void PictureBox16_Click(object sender, EventArgs e)
        {
            try {
                users = sql.OneLine(quary: "Select `Исполнитель` from orders where `Компания` = '"+ dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.ToString() + "'");
                statis = Convert.ToInt32(sql.OneLine(quary: "Select `Кол-во работ` from stat Where `Пользователь` = '"+users+"';"));
                sql.CommandToTable("Update `stat` Set `Кол-во работ` = '" + (statis = statis - 1) + "' where `Пользователь` = '"+users+"'");
                sql.CommandToTable("Update `stat` Set `Последняя выполненая` = '' where `Пользователь` = '" + users + "'");
                sql.CommandToTable("Update `orders` Set `Статус` = 'Не выполнен',`Исполнитель` = '' where `Компания` = '" + dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.ToString() + "';");
                update();
            }
            catch (NullReferenceException)
            { MessageBox.Show(SetLanguage.SetString("Выберете запись")); }
        }
        private void PictureBox17_Click(object sender, EventArgs e)
        {
            try
            {
                users = sql.OneLine(quary: "Select `Исполнитель` from orders where `Компания` = '" + dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.ToString() + "'");
                statis = Convert.ToInt32(sql.OneLine(quary: "Select `Кол-во работ` from stat Where `Пользователь` = '" + users + "';"));
                sql.CommandToTable("Update `stat` Set `Кол-во работ` = '" + (statis = statis - 1) + "' where `Пользователь` = '" + users + "'");
                sql.CommandToTable("Update `stat` Set `Последняя выполненая` = '' where `Пользователь` = '" + users + "'");
                sql.CommandToTable("Update `orders` Set `Статус` = 'На выполнение' where `Компания` = '" + dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value.ToString() + "';");
                update();
            }
            catch (NullReferenceException)
            { MessageBox.Show(SetLanguage.SetString("Выберете запись")); }
        }
        private void PictureBox5_Click(object sender, EventArgs e)
        {
            sql.CommandToTable("INSERT INTO `orders` (`id`, `ФИО`, `Компания`, `Телефон / Email`, `Описание`, `Доп.информация`, `Дата поступления`, `Статус`, `Исполнитель`) VALUES (NULL, '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox11.Text + "', '" + textBox11.Text + "', '" + dateTimePicker1.Value.Date.ToShortDateString() + "', 'Не выполнено', '');");
            update();
        }
        private void PictureBox19_Click(object sender, EventArgs e)
        {
            if (textBox14.Text == textBox15.Text)
            {
                sql.CommandToTable("Insert into `authorization`(`ID`,`Login`,`Pass`) Values (NULL,'" + textBox99.Text + "','" + textBox15.Text + "');");
                sql.CommandToTable("INSERT INTO `stat`(`id_stat`, `Пользователь`, `Кол-во работ`, `Последняя выполненая`) VALUES (null,'" + textBox99.Text + "',0,'');");
            }
            else
                MessageBox.Show(SetLanguage.SetString("Не совпадение паролей"), SetLanguage.SetString("Ошибка"));

            update();
        }
        private void PictureBox15_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show(SetLanguage.SetString("Вы уверены что хотите удалить заказ?"), SetLanguage.SetString("Сообщение"), MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                    sql.CommandToTable("delete From `orders` where `Компания` = '" + dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString() + "';");
                update();
            }
            catch (NullReferenceException)
            { MessageBox.Show(SetLanguage.SetString("Выберете запись")); }
        }
        private void PictureBox20_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedtable == true)
                {
                    DialogResult res = MessageBox.Show(SetLanguage.SetString("Вы уверены что хотите удалить пользователя?"), SetLanguage.SetString("Сообщение"), MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                        sql.CommandToTable("delete From `stat` where `id_stat` = '" + dataGridView6[0, dataGridView6.CurrentCell.RowIndex].Value.ToString() + "';");
                }
                else
                {
                    DialogResult res = MessageBox.Show(SetLanguage.SetString("Вы уверены что хотите удалить пользователя?"), SetLanguage.SetString("Сообщение"), MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                        sql.CommandToTable("delete From `authorization` where `ID` = '" + dataGridView5[0, dataGridView5.CurrentCell.RowIndex].Value.ToString() + "';");
                }
                update();
            }
            catch (NullReferenceException)
            { MessageBox.Show(SetLanguage.SetString("Выберете запись")); }
        }
        private void PictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show(SetLanguage.SetString("Вы уверены что хотите удалить заказ?"), SetLanguage.SetString("Сообщение"), MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                    sql.CommandToTable("delete From `orders` where `id` = '" + dataGridView4[0, dataGridView4.CurrentCell.RowIndex].Value.ToString() + "';");
                update();
            }
            catch (NullReferenceException)
            { MessageBox.Show(SetLanguage.SetString("Выберете запись")); }
        }
        #region изменения
        private void PictureBox8_Click(object sender, EventArgs e)
        {
            textBox18.Show();
            button100.Show();
            button99.Show();
        }
        private void Button99_Click(object sender, EventArgs e)
        {
            textBox18.Hide();
            button100.Hide();
            button99.Hide();
        }
        private void Button100_Click(object sender, EventArgs e)
        {
            sql.CommandToTable("Update `orders` Set `" + dataGridView4.CurrentCell.OwningColumn.Name.ToString() + "` = '" + textBox18.Text + "' where `id` = '" + dataGridView4[0, dataGridView4.CurrentCell.RowIndex].Value.ToString() + "';");
            update();
            textBox18.Hide();
            button100.Hide();
            button99.Hide();
        }
        //Второе изменение
        private void Button98_Click(object sender, EventArgs e)
        {
            if(selectedtable == true)
                sql.CommandToTable("Update `stat` Set `" + dataGridView6.CurrentCell.OwningColumn.Name.ToString() + "` = '" + textBox98.Text + "' where `id_stat` = '" + dataGridView6[0, dataGridView6.CurrentCell.RowIndex].Value.ToString() + "';");
            else
                sql.CommandToTable("Update `authorization` Set `" + dataGridView5.CurrentCell.OwningColumn.Name.ToString() + "` = '" + textBox98.Text + "' where `ID` = '" + dataGridView5[0, dataGridView5.CurrentCell.RowIndex].Value.ToString() + "';");
            update();
            textBox98.Hide();
            button98.Hide();
            button97.Hide();
        }
        private void PictureBox23_Click(object sender, EventArgs e)
        {
            textBox98.Show();
            button98.Show();
            button97.Show();

        }
        private void Button97_Click(object sender, EventArgs e)
        {
            textBox98.Hide();
            button98.Hide();
            button97.Hide();
        }
        #endregion
        private void PictureBox13_Click(object sender, EventArgs e)
        {
            try
            {
                sql.CommandToTable("Update `orders` Set `Статус` = 'Не выполнен',`Исполнитель` = '' where `Компания` = '" + dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString() + "';");
                update();
            }
            catch (NullReferenceException)
            { MessageBox.Show(SetLanguage.SetString("Выберете запись")); }
        }
        #endregion
        //реализовать нормальную смену таблиц
        #region поиск
        private void TextBox19_TextChanged(object sender, EventArgs e)
        {
            string buff = textBox19.Text;
            buff.Replace("'", buff);
            if(Form1.user != "admin")
                dataGridView1.DataSource = sql.Show(quary: "Select `Компания`,`Телефон / Email`,`Дата поступления` From `orders` where `" + comboBox2.SelectedItem + "` like '" + textBox19.Text + "%' and `Статус` = 'Не выполнен'; ");
            else
                dataGridView1.DataSource = sql.Show(quary: "Select `Компания`,`Телефон / Email`,`Дата поступления`,`Статус`,`Исполнитель` From `orders` where `" + comboBox2.SelectedItem + "` like '" + textBox19.Text + "%'; ");
        }

        private void TextBox20_TextChanged(object sender, EventArgs e)
        {
            string buff = textBox20.Text;
            buff.Replace("'", buff);
            if (Form1.user != "admin")
                dataGridView2.DataSource = sql.Show(quary: "Select `Компания`,`Телефон / Email`,`Дата поступления` From `orders` where `" + comboBox3.SelectedItem + "` like '" + textBox20.Text + "%' and `Статус` = 'На выполнение' and `Исполнитель` = '" + Form1.user + "';");
            else
                dataGridView2.DataSource = sql.Show(quary: "Select `Компания`,`Телефон / Email`,`Дата поступления`,`Статус`,`Исполнитель` From `orders` where `" + comboBox3.SelectedItem + "` like '" + textBox20.Text + "%' and `Статус` = 'На выполнение'; ");
        }

        private void TextBox21_TextChanged(object sender, EventArgs e)
        {
            string buff = textBox21.Text;
            buff.Replace("'", buff);
            if (Form1.user != "admin")
                dataGridView3.DataSource = sql.Show(quary: "Select `Компания`,`Телефон / Email`,`Дата поступления` From `orders` where `" + comboBox4.SelectedItem + "` like '" + textBox21.Text + "%' and `Статус` = 'Выполнен' and `Исполнитель` = '" + Form1.user + "'; ");
            else
                dataGridView3.DataSource = sql.Show(quary: "Select `Компания`,`Телефон / Email`,`Дата поступления`,`Статус`,`Исполнитель` From `orders` where `" + comboBox4.SelectedItem + "` like '" + textBox21.Text + "%' and `Статус` = 'Выполнен';");
        }

        private void TextBox22_TextChanged(object sender, EventArgs e)
        {
            string buff = textBox22.Text;
            buff.Replace("'", buff);
            dataGridView4.DataSource = sql.Show(quary: "Select `ФИО`,`Компания`,`Телефон / Email`,`Дата поступления`,`Статус`,`Исполнитель` From `orders` where `" + comboBox1.SelectedItem + "` like '" + textBox22.Text + "%'; ");
        }
        private void TextBox100_TextChanged(object sender, EventArgs e)
        {
            string buff = textBox100.Text;
            buff.Replace("'", buff);
            if (selectedtable == true)
                dataGridView6.DataSource = sql.Show(quary: "Select * From `stat` where `" + comboBox100.SelectedItem + "` like '" + textBox100.Text + "%'; ");
            else
                dataGridView5.DataSource = sql.Show(quary: "Select * From `authorization` where `" + comboBox100.SelectedItem + "` like '" + textBox100.Text + "%'; ");
        }
        #endregion 
        private void PictureBox24_Click(object sender, EventArgs e)
        {
            selectedtable = true;
            pictureBox24.Image = Image.FromFile(Application.StartupPath + "\\picture\\right-arrow-blue.png");
            pictureBox25.Image = Image.FromFile(Application.StartupPath + "\\picture\\right-arrow.png");
            comboBox100.Items.Clear();
            comboBox100.Items.AddRange(new string[] { "id_stat", "Пользователь", "Кол-во работ", "Последняя выполненая" });
            comboBox100.SelectedIndex = 0;
            dataGridView6.Enabled = true;
            dataGridView5.Enabled = false;
            pictureBox22.BackColor = Color.Blue;
            pictureBox21.BackColor = Color.Black;

        }
        private void PictureBox25_Click(object sender, EventArgs e)
        {
            selectedtable = false;
            pictureBox25.Image = Image.FromFile(Application.StartupPath + "\\picture\\left-arrow-blue.png");
            pictureBox24.Image = Image.FromFile(Application.StartupPath + "\\picture\\left-arrow.png");
            comboBox100.Items.Clear();
            comboBox100.Items.AddRange(new string[] { "ID", "Login", "Pass"});
            comboBox100.SelectedIndex = 0;
            dataGridView6.Enabled = false;
            dataGridView5.Enabled = true;
            pictureBox21.BackColor = Color.Blue;
            pictureBox22.BackColor = Color.Black;
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
