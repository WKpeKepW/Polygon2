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
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "Ip хоста", "Ip host" },
                { "Порт", "Port" },
                { "Название базы", "Name of DB" },
                { "Имя юзера", "Name of user" },
                { "Пароль", "Password" },
                { "Код. конекта", "Code. connect" },
                { "Изменить", "Change" },
                { "Настройки успешно изменены", "Settings successful change" },
                { "Настройки", "Settings" },
                { "Ошибка авторизации", "Error Authorization" },
                { "Авторизация", "Authorization" },
                { "Логин", "Login" },
                { "Заказы", "Orders" },
                { "Мои заказы", "My orders" },
                { "История", "History" },
                { "Данные о заказах", "Order data" },
                { "Данные о пользователях", "Users data" },
                { "Меню", "Menu" },
                { "ФИО", "Name" },
                { "Описание", "Description" },
                { "Доп.информация", "Add.Information" },
                { "Поиск:", "Search:" },
                { "Компания", "Company" },
                { "Телефон или Email", "PhoneNuber or Email" },
                { "Отмена", "Cancel" },
                { "Имя пользователя", "User name" },
                { "Повторить пароль", "Repeat password" },
                { "Выберете запись", "Select notation" },
                { "Не совпадение паролей", "Password mismatch" },
                { "Ошибка", "Error" },
                { "Вы уверены что хотите удалить заказ?", "Are you sure you want to delete the order?" },
                { "Сообщение", "Messege" },
                { "Вы уверены что хотите удалить пользователя?", "Are you sure you want to delete the user?" },
                { "Вы уверены что хотите выйти?","Are you sure you want to logout?" }
            };
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
