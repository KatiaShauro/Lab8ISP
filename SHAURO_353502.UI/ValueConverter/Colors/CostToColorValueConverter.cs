using System.Globalization;


namespace SHAURO_353502.UI.ValueConverter
{
    public class CostToColorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                             CultureInfo culture)
        {
            if ((double)value > 120)
                return Colors.Red;
            else if ((double)value > 70)
                return Colors.Gold;
            return Colors.ForestGreen;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                 CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
