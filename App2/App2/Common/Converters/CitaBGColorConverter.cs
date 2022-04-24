using System;
using System.Globalization;
using Xamarin.Forms;
using Syncfusion.SfCalendar.XForms;
namespace Care_Taker.Common.Converters
{
    internal class CitaBGColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var startTime = (DateTime)value;
            if(startTime != null)
            {
                if (startTime.Date > DateTime.Now.Date)
                {
                    return Color.Green;
                }
                else if (startTime < DateTime.Now)
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Turquoise;
                }
            }
            return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
