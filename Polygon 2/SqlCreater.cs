using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygon_2
{
    class SqlCreater
    {
        MySqlConnection connect;
        MySqlConnectionStringBuilder mysqlconstr;
        StreamReader Sr;
        DataTable dt;
        MySqlDataReader dr;
        MySqlCommand cmd;
        public int Exeptionerror = 0;
        public SqlCreater()
        {
            //Пересмотреть способ подключения так как обычный пользователь не может видить пароль от базы данных
            Sr = new StreamReader(Application.StartupPath+"\\config.txt");
            string text = Sr.ReadToEnd();
            string[] buff = text.Split(';');
            mysqlconstr = new MySqlConnectionStringBuilder
            {
                Server = buff[0],
                Port = Convert.ToUInt32(buff[1]),
                Database = buff[2],
                UserID = buff[3],
                Password = buff[4],
                CharacterSet = buff[5]
            };
            connect = new MySqlConnection(mysqlconstr.ToString());
        }
        public DataTable Show(string nametable = "test", string quary = "")
        {
            if (quary == "")
            {quary = "Select * From `" + nametable + "`;";}
            dt = new DataTable();
            try
            {connect.Open();}
            catch (Exception e)
            {MessageBox.Show(e.Message); connect.Close(); Exeptionerror = 1; return new DataTable();}
            cmd = new MySqlCommand(quary, connect);
            try { dr = cmd.ExecuteReader();}
            catch (Exception e)
            { MessageBox.Show(e.Message); connect.Close(); dr.Close(); Exeptionerror = 2; return new DataTable(); }
            dt.Load(dr);
            dr.Close();
            connect.Close();
            return dt;
        }
        public void CommandToTable(string quary)
        {
            connect.Open();
            cmd = new MySqlCommand(quary, connect);
            try { cmd.ExecuteNonQuery(); }
            catch (Exception e) { MessageBox.Show(e.Message); }
            connect.Close();
        }
        public string OneLine(string nametable = null, string NameColumn = null, string NameIF = null, string quary = null)
        {
            if (quary == null)
                cmd = new MySqlCommand("SELECT `" + NameColumn + "` FROM `" + nametable + "` WHERE `Компания` = '" + NameIF + "' ", connect);
            else
                cmd = new MySqlCommand(quary,connect);
            connect.Open();
            dr = cmd.ExecuteReader();
            string buff = null;
            while (dr.Read())
            { buff = dr.GetValue(0).ToString(); }
            connect.Close();
            dr.Close();
            return buff;
        }
    }
}
