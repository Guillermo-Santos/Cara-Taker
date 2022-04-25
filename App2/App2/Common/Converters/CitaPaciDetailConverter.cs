using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Care_Taker.Models;

namespace Care_Taker.Common.Converters
{
    internal class CitaPaciDetailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Persona persona = (Persona)value;
            return $"Cita con {persona.Nombre} {persona.Apellidos}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
