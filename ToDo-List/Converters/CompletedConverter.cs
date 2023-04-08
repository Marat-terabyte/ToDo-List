using System;
using System.Globalization;
using System.Windows.Data;

namespace ToDo_List
{
    internal class CompletedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return "Done";

            return "Not done";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((string)value).Equals("Done"))
                return true;

            return false;
        }
    }
}
