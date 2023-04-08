using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ToDo_List.Converters
{
    class DatePickerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            return (string)value;
        }
    }
}
