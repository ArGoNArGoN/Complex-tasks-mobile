using System;
using System.Globalization;
using Xamarin.Forms;

namespace project.Views.DataTemplateSelectors
{
    public class ToDoTemplateSelector
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.GetType().Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
