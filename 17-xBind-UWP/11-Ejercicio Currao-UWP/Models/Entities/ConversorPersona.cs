using _05_PersonaModificada_ASP.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _11_Ejercicio_Currao_UWP.Models.Entities
{
    public class ConversorPersona : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            clsPersona persona = (clsPersona) value;
            return persona;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
