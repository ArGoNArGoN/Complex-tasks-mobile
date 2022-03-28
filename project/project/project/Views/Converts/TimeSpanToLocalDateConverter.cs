using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace project.Views.Converts
{
    public class TimeSpanToLocalDateConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new TimeSpan();
        }
    }
}
