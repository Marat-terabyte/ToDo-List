﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ToDo_List.Converters
{
    class DatePickerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not null && value.ToString().Length != 0)
                return System.Convert.ToDateTime(value);

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value;
        }
    }
}
