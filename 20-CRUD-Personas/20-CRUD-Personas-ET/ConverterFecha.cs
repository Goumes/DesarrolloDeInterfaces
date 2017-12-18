using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _20_CRUD_Personas_ET
{
    public class ConverterFecha : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String fecha2 = null;

            fecha2 = value.ToString();
            fecha2 = fecha2.Substring(0, 10);
            return fecha2;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTime fecha2 = new DateTime ();

            fecha2 = System.Convert.ToDateTime (value);

            return fecha2;

        }
    }
}
