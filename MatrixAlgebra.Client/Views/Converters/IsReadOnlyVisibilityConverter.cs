using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MatrixAlgebra.Client.Views.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class IsReadOnlyVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? isReadOnly = value as bool?;

            return isReadOnly == true ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility? visibility = value as Visibility?;

            return visibility == Visibility.Visible;
        }
    }
}
