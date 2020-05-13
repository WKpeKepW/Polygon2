using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygon_2
{
    static class SetLanguage
    {
        static public bool IsEnglishOn = false;
        static Dictionary<string, string> DictianaryofLanguage()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Ip хоста", "Ip host");
            dict.Add("Порт", "Port");
            dict.Add("Название базы", "Name of DB");
            dict.Add("Имя юзера", "Name of user");
            dict.Add("Пароль", "Password");
            dict.Add("Код. конекта", "Code. connect");
            dict.Add("Изменить", "Change");
            dict.Add("Настройки успешно изменены", "Settings successful change");
            dict.Add("Настройки", "Settings");
            dict.Add("Ошибка авторизации", "Error Authorization");
            dict.Add("Авторизация", "Authorization");
            dict.Add("Логин", "Login");
            dict.Add("Заказы","Orders");
            dict.Add("Мои заказы", "My orders");
            dict.Add("История", "History");
            dict.Add("Данные о заказах", "Order data");
            dict.Add("Данные о пользователях","Users data");
            dict.Add("Меню","Menu");
            dict.Add("ФИО", "Name");
            dict.Add("Описание", "Description");
            dict.Add("Доп.информация", "Add.Information");
            dict.Add("Поиск:","Search:");
            dict.Add("Компания","Company");
            dict.Add("Телефон или Email","PhoneNuber or Email");
            dict.Add("Отмена","Cancel");
            dict.Add("Имя пользователя","User name");
            dict.Add("Повторить пароль","Repeat password");
            dict.Add("Выберете запись", "Select notation");
            dict.Add("Не совпадение паролей","Password mismatch");
            dict.Add("Ошибка", "Error");
            dict.Add("Вы уверены что хотите удалить заказ?", "Are you sure you want to delete the order?");
            dict.Add("Сообщение","Messege");
            dict.Add("Вы уверены что хотите удалить пользователя?", "Are you sure you want to delete the user?");
            return dict;
        }
        static public void Set(Control This)
        {
            if (IsEnglishOn)
            {
                foreach (Control I in This.Controls)
                {
                    if ((I is Label) || (I is Button))
                    {
                        I.Text = SetLanguage.En(I.Text);
                    }
                    else if(I is TabControl)
                    {
                        foreach (Control K in I.Controls)
                        {
                            if (K is TabPage)
                            {
                                foreach (Control J in K.Controls)
                                {
                                    if ((J is Label) || (J is Button))
                                    {
                                        J.Text = SetLanguage.En(J.Text);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Control I in This.Controls)
                {
                    if ((I is Label) || (I is Button))
                    {
                        I.Text = SetLanguage.Ru(I.Text);
                    }
                    else if (I is TabControl)
                    {
                        foreach (Control K in I.Controls)
                        {
                            if (K is TabPage)
                            {
                                foreach (Control J in K.Controls)
                                {
                                    if ((J is Label) || (J is Button))
                                    {
                                        J.Text = SetLanguage.Ru(J.Text);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        static public string SetString(string s)
        {
            if (IsEnglishOn)
                return En(s);
            else
                return Ru(s);
        }
        static string En(string s)
        {
            var dict = DictianaryofLanguage();
            int i = 0;
            foreach (var k in dict.Keys)
            {
                if (k == s)
                    return dict.ElementAt(i).Value;
                i++;
            }
            if (true)
            {
                return s;
            }
        }
        static string Ru(string s)
        {
            var dict = DictianaryofLanguage();
            int i = 0;
            foreach (var k in dict.Values)
            {
                if (k == s)
                    return dict.ElementAt(i).Key;
                i++;
            }
            if (true)
            {
                return s;
            }
        }
    }
}
