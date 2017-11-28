using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace KMP_Presentation
{
    class NotLessThanZeroToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value < 0 ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class TimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((TimeSpan)value).TotalMilliseconds;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TimeSpan.FromMilliseconds((double)value);
        }
    }
    class BackgroundColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool ia = (bool)values[0];
            int li = (int)values[1];
            char uc = (char)values[2];
            char lc = (char)values[3];
            bool bd = (bool)values[4];
            if (ia)
                return Colors.LightSkyBlue;
            if (bd || li == -1)
                return Colors.White;
            if (uc == lc)
                return Colors.LightGreen;
            return Colors.LightPink;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class IndexConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int v = (int)values[0];
            int p = (int)values[1];
            return v == p ? Colors.LightPink : Colors.White;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RandomConverter : IValueConverter
    {
        Random rand = new Random();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double param = (double)parameter;
            return rand.NextDouble() * param * 2 - param;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
