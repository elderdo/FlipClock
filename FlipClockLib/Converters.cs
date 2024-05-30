#region Using Directives

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

#endregion

namespace Standard.Controls
{
    public class DoubleAddOperationConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var originalValue = (double) value;

            var amountToAdd = double.Parse(parameter.ToString());

            return originalValue + amountToAdd;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }

    public class DoubleMultiplyOperationConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var originalValue = (double) value;

            var amountToMultiply = double.Parse(parameter.ToString());

            return originalValue*amountToMultiply;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }

    public class VisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isVisibile = (bool) value;

            if (isVisibile)
            {
                return Visibility.Visible;
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}