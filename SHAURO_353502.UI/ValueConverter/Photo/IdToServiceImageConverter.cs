using System.Globalization;


namespace SHAURO_353502.UI.ValueConverter
{
    public class IdToServiceImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not int id)
                return ImageSource.FromFile("placeholder.png");

            string filePath = Path.GetFullPath(Path.Combine
                (AppContext.BaseDirectory,
                @"..\..\..\..\..\",
                "Images\\Services",
                $"{id}.png")
            );
            return File.Exists(filePath)
                ? ImageSource.FromFile(filePath)
                : ImageSource.FromFile("placeholder.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}

