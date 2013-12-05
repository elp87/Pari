using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;

namespace PariClasses
{
    public static class checkDemo
    {
        //private const bool isDemo = false;
        public static bool getDemo() { return Constants.isDemo; }
        public static void checkObj(List<person> lp)
        {
            if (Constants.isDemo == false) return;
            if (lp.Count == 0)
            {
                message(-1);
                return;
            }
            DateTime minDate;
            TimeSpan tsDateDif;
            int intDateDif;
            minDate = Convert.ToDateTime((from ft in lp select ft.testDate).Min());
            tsDateDif = DateTime.Now - minDate;
            intDateDif = tsDateDif.Days;
            message(intDateDif);
        }

        public static void checkData(DataTable dt)
        {
            if (Constants.isDemo == false) return;
            TimeSpan tsDateDif;
            int intDateDif;
            DateTime minDate = (from ps in dt.AsEnumerable() select ps.Field<DateTime>("testDate")).Min();
            tsDateDif = DateTime.Now - minDate;
            intDateDif = tsDateDif.Days;
            message(intDateDif);
        }
        public static void checkData()
        {
            message(-1);
        }

        private static void message(int dif)
        {
            if (dif == -1)
            {
                MessageBox.Show("Вы используете демо-версию программы. Демо-период - 10 дней" + '\n' +
                    "Пожалуйста, приобретите полную версию программы." + '\n' +
                    "Россия: +7-926-719-69-41 - Александр." + '\n' +
                    "Украина: +38-099-545-97-55 - Алена." + '\n' +
                    "email: mdsoft@yandex.ru");
                return;
            }
            if (dif > 10)
            {
                MessageBox.Show("Использование демо-версии разрешено не более 10 дней." + '\n' +
                    "Пожалуйста, приобретите полную версию программы." + '\n' +
                    "Россия: +7-926-719-69-41 - Александр." + '\n' +
                    "Украина: +38-099-545-97-55 - Алена." + '\n' +
                    "email: mdsoft@yandex.ru");
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("До конца демо-периода осталось - " + Convert.ToString(10 - dif) + "дней." + '\n' +
                    "Пожалуйста, приобретите полную версию программы." + '\n' +
                    "Россия: +7-926-719-69-41 - Александр." + '\n' +
                    "Украина: +38-099-545-97-55 - Алена." + '\n' +
                    "email: mdsoft@yandex.ru");
            }
        }
    }
}
