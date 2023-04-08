using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MatrixAlgebra.Client.Views.Converters
{
    [ValueConversion(typeof(bool?), typeof(Visibility))]
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value as bool? == true 
                ? Visibility.Visible 
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility? visibility = value as Visibility?;

            return visibility == Visibility.Visible;
        }
    }
}
