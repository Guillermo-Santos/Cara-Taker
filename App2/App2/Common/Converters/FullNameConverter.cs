using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Care_Taker.Models;

namespace Care_Taker.Common.Converters
{
    public class FullNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Persona persona = (Persona)value;
            return $"{persona.Nombre} {persona.Apellidos}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
