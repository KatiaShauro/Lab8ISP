using System.Globalization;


namespace SHAURO_353502.UI.ValueConverter
{
    public class IdToRoomImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not int id)
                return ImageSource.FromFile("placeholder.png");

            string root = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\..\", "Images\\Rooms", $"{id}.png"));
            return File.Exists(root)
                ? ImageSource.FromFile(root)
                : ImageSource.FromFile("placeholder.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
