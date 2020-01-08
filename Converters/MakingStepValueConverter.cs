using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using VendoreMachine.Dto;

namespace VendoreMachine.Converters
{
    class MakingStepValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var type = (BeverageMakingStepState)values[0];
            BitmapImage bmp = new BitmapImage(new Uri(values[(int)(BeverageMakingStepState)values[0] + 1].ToString(), UriKind.Absolute));
            return bmp;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
