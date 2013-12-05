using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace PariClasses
{
    public class ListBoxColor : IValueConverter//Конвертер для аспектов
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush curBrush = new SolidColorBrush();
            string textColor = "#0000FF";
            if ((int)value <= 8) textColor = "#FF0000";
            if ((int)value >= 18) textColor = "#00A400";
            ColorConverter bc = new ColorConverter();
            curBrush.Color = (Color)bc.ConvertFrom(textColor);
            return curBrush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    /*public class StringItem//Вспомогательный класс для обертки текста элементов ListBoxPersons в PariTrainer.MainWindow
    {
        public string strValue { get; set; }
        public StringItem(string str)
        {
            this.strValue = str;
        }

        public override string ToString()
        {
            return strValue;
        }
    }*/
}
