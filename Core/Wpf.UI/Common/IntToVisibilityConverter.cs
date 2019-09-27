using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfUI.Common
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public sealed class IntToVisibilityConverter : IValueConverter
    {
        public Visibility TrueVisibilityValue { get; set; }
        public Visibility FalseVisibilityValue { get; set; }

        public int? IntTrueValue { get; set; }

        public IntToVisibilityConverter()
        {
            // set defaults
            TrueVisibilityValue = Visibility.Visible;
            FalseVisibilityValue = Visibility.Collapsed;
            IntTrueValue = 0;
        }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (!(value is int))
                return null;

            var intValue = (int) value;
            if (IntTrueValue.HasValue && intValue == IntTrueValue)
                return TrueVisibilityValue;
            return FalseVisibilityValue;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (Equals(value, TrueVisibilityValue))
                return 0;
            if (Equals(value, FalseVisibilityValue))
                return 1;
            return null;
        }
    }
}