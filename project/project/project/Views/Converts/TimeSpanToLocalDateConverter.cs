using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace project.Views.Converts
{
    /// <summary>
    /// Конвертер для 
    /// </summary>
    public class TimeSpanToLocalDateConverter
        : IValueConverter
    {
        /// <summary>
        /// Конвертирует в дату в строку.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>строку с временем</returns>
        public Object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var time = (TimeSpan)value;

            var str = "";

            if (time.Days != 0)
                str += $"{time.Days} д. ";

            if (time.Hours == 0 && time.Minutes > 0)
                str += $"1 ч.";
            else
                str += $"{time.Hours} ч.";

            return str;
        }

        /// <summary>
        /// Ничего не делает. Не использовать.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public Object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new TimeSpan();
        }
    }
}
