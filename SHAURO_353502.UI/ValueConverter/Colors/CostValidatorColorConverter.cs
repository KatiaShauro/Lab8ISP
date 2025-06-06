﻿using System.Globalization;


namespace SHAURO_353502.UI.ValueConverter
{
    public class CostValidatorColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                             CultureInfo culture)
        {
            if (value == null || value == string.Empty)
                return Colors.Azure;
            if (!double.TryParse(value.ToString(), out double num))
                return Colors.Red;
            return Colors.Azure;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                 CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
