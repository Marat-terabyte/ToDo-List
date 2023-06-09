﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace ToDo_List
{
    class ForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return "Green";

            return "Red";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString().Equals("green"))
                return true;

            return false;
        }
    }
}
