using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace KMP_Presentation
{
    class PresentationConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            List<Presenter> list = new List<Presenter>();
            string Source = (string)values[0];
            string Word = (string)values[1];
            int Position = (int)values[2];
            int Checking = (int)values[3];
            for (int i = 0; i < Source.Length; ++i)
            {
                Presenter p = new Presenter();
                p.UpperIndex = i;
                p.UpperChar = Source[i];
                if (Position <= i && Position + Word.Length > i && Checking >= i)
                {
                    p.LowerIndex = i - Position;
                    p.LowerChar = Word[i - Position];
                }
                list.Add(p);
            }
            return list;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
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
}
