using FitnessCenter.BD.EntitiesBD.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FitnessCenter.Converters
{
    public class ServicesListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ICollection<Services> ServicesCollection)
            {
                StringBuilder str = new StringBuilder();

                foreach (Services services in ServicesCollection)
                {
                    str.Append(services.ToString());
                }

                return str.ToString();
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
